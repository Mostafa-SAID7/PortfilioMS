/**
 * Contact Form Handler
 * Handles form submission, validation, and user feedback
 */

(function() {
  'use strict';

  // ============================================
  // Configuration
  // ============================================
  const config = {
    apiEndpoint: '/api/contact',
    validationRules: {
      name: {
        minLength: 2,
        maxLength: 100,
        pattern: /^[a-zA-Z\s'-]+$/
      },
      email: {
        pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/
      },
      subject: {
        minLength: 5,
        maxLength: 200
      },
      message: {
        minLength: 10,
        maxLength: 5000
      }
    },
    messages: {
      success: 'Thank you for your message! I\'ll get back to you soon.',
      error: 'Oops! Something went wrong. Please try again later.',
      validation: {
        required: 'This field is required',
        email: 'Please enter a valid email address',
        minLength: 'This field must be at least {min} characters',
        maxLength: 'This field must not exceed {max} characters',
        pattern: 'Please enter a valid value'
      }
    }
  };

  // ============================================
  // Contact Form Class
  // ============================================
  class ContactForm {
    constructor(formSelector) {
      this.form = document.querySelector(formSelector);
      if (!this.form) return;

      this.fields = {
        name: this.form.querySelector('[name="name"]'),
        email: this.form.querySelector('[name="email"]'),
        subject: this.form.querySelector('[name="subject"]'),
        message: this.form.querySelector('[name="message"]')
      };

      this.submitButton = this.form.querySelector('[type="submit"]');
      this.notification = null;

      this.init();
    }

    init() {
      this.bindEvents();
      this.setupCharacterCounters();
    }

    bindEvents() {
      // Form submission
      this.form.addEventListener('submit', (e) => this.handleSubmit(e));

      // Real-time validation
      Object.keys(this.fields).forEach(fieldName => {
        const field = this.fields[fieldName];
        
        field.addEventListener('blur', () => {
          if (field.value.trim()) {
            this.validateField(fieldName);
          }
        });

        field.addEventListener('input', () => {
          if (field.classList.contains('is-invalid')) {
            this.validateField(fieldName);
          }
        });
      });
    }

    setupCharacterCounters() {
      const fieldsWithCounter = ['subject', 'message'];
      
      fieldsWithCounter.forEach(fieldName => {
        const field = this.fields[fieldName];
        const maxLength = config.validationRules[fieldName].maxLength;
        const counterElement = this.createCounter(field, maxLength);
        
        field.addEventListener('input', () => {
          this.updateCounter(field, counterElement, maxLength);
        });
      });
    }

    createCounter(field, maxLength) {
      const counter = document.createElement('div');
      counter.className = 'character-counter';
      counter.textContent = `0 / ${maxLength}`;
      field.parentElement.appendChild(counter);
      return counter;
    }

    updateCounter(field, counterElement, maxLength) {
      const currentLength = field.value.length;
      counterElement.textContent = `${currentLength} / ${maxLength}`;
      
      if (currentLength > maxLength * 0.9) {
        counterElement.classList.add('warning');
      } else {
        counterElement.classList.remove('warning');
      }
    }

    validateField(fieldName) {
      const field = this.fields[fieldName];
      const value = field.value.trim();
      const rules = config.validationRules[fieldName];
      let errorMessage = '';

      // Required check
      if (!value) {
        errorMessage = config.messages.validation.required;
      }
      // Min length check
      else if (rules.minLength && value.length < rules.minLength) {
        errorMessage = config.messages.validation.minLength.replace('{min}', rules.minLength);
      }
      // Max length check
      else if (rules.maxLength && value.length > rules.maxLength) {
        errorMessage = config.messages.validation.maxLength.replace('{max}', rules.maxLength);
      }
      // Pattern check
      else if (rules.pattern && !rules.pattern.test(value)) {
        if (fieldName === 'email') {
          errorMessage = config.messages.validation.email;
        } else {
          errorMessage = config.messages.validation.pattern;
        }
      }

      this.showFieldValidation(field, errorMessage);
      return !errorMessage;
    }

    showFieldValidation(field, errorMessage) {
      const feedbackElement = field.parentElement.querySelector('.invalid-feedback') || 
                             this.createFeedbackElement(field);

      if (errorMessage) {
        field.classList.add('is-invalid');
        field.classList.remove('is-valid');
        feedbackElement.textContent = errorMessage;
      } else {
        field.classList.remove('is-invalid');
        field.classList.add('is-valid');
        feedbackElement.textContent = '';
      }
    }

    createFeedbackElement(field) {
      const feedback = document.createElement('div');
      feedback.className = 'invalid-feedback';
      field.parentElement.appendChild(feedback);
      return feedback;
    }

    validateForm() {
      let isValid = true;

      Object.keys(this.fields).forEach(fieldName => {
        if (!this.validateField(fieldName)) {
          isValid = false;
        }
      });

      return isValid;
    }

    async handleSubmit(e) {
      e.preventDefault();

      // Validate form
      if (!this.validateForm()) {
        this.showNotification('Please fix the errors before submitting', 'error');
        return;
      }

      // Disable submit button
      this.setSubmitState(true);

      // Collect form data
      const formData = {
        name: this.fields.name.value.trim(),
        email: this.fields.email.value.trim(),
        subject: this.fields.subject.value.trim(),
        message: this.fields.message.value.trim(),
        timestamp: new Date().toISOString()
      };

      try {
        const response = await this.submitForm(formData);

        if (response.success) {
          this.showNotification(config.messages.success, 'success');
          this.resetForm();
          
          // Track success (Google Analytics, etc.)
          this.trackFormSubmission('success');
        } else {
          throw new Error(response.message || 'Submission failed');
        }
      } catch (error) {
        console.error('Form submission error:', error);
        this.showNotification(config.messages.error, 'error');
        this.trackFormSubmission('error');
      } finally {
        this.setSubmitState(false);
      }
    }

    async submitForm(formData) {
      const response = await fetch(config.apiEndpoint, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'X-Requested-With': 'XMLHttpRequest'
        },
        body: JSON.stringify(formData)
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      return await response.json();
    }

    setSubmitState(isLoading) {
      if (isLoading) {
        this.submitButton.disabled = true;
        this.submitButton.classList.add('btn-loading');
        this.submitButton.setAttribute('data-original-text', this.submitButton.textContent);
        this.submitButton.textContent = 'Sending...';
      } else {
        this.submitButton.disabled = false;
        this.submitButton.classList.remove('btn-loading');
        const originalText = this.submitButton.getAttribute('data-original-text');
        if (originalText) {
          this.submitButton.textContent = originalText;
        }
      }
    }

    resetForm() {
      this.form.reset();
      
      // Remove validation classes
      Object.values(this.fields).forEach(field => {
        field.classList.remove('is-valid', 'is-invalid');
      });

      // Reset character counters
      const counters = this.form.querySelectorAll('.character-counter');
      counters.forEach(counter => {
        const maxLength = counter.textContent.split(' / ')[1];
        counter.textContent = `0 / ${maxLength}`;
        counter.classList.remove('warning');
      });
    }

    showNotification(message, type = 'info') {
      // Remove existing notification
      if (this.notification) {
        this.notification.remove();
      }

      // Create new notification
      this.notification = document.createElement('div');
      this.notification.className = `notification notification-${type}`;
      this.notification.innerHTML = `
        <div class="notification-content">
          <span class="notification-icon">${this.getNotificationIcon(type)}</span>
          <span class="notification-message">${message}</span>
          <button class="notification-close" aria-label="Close">&times;</button>
        </div>
      `;

      // Add to DOM
      document.body.appendChild(this.notification);

      // Show with animation
      setTimeout(() => {
        this.notification.classList.add('show');
      }, 10);

      // Auto-hide after 5 seconds
      setTimeout(() => {
        this.hideNotification();
      }, 5000);

      // Close button
      this.notification.querySelector('.notification-close').addEventListener('click', () => {
        this.hideNotification();
      });
    }

    hideNotification() {
      if (this.notification) {
        this.notification.classList.remove('show');
        setTimeout(() => {
          this.notification.remove();
          this.notification = null;
        }, 300);
      }
    }

    getNotificationIcon(type) {
      const icons = {
        success: '✓',
        error: '✕',
        warning: '⚠',
        info: 'ℹ'
      };
      return icons[type] || icons.info;
    }

    trackFormSubmission(status) {
      // Google Analytics tracking
      if (typeof gtag !== 'undefined') {
        gtag('event', 'form_submission', {
          event_category: 'Contact Form',
          event_label: status,
          value: 1
        });
      }

      // Facebook Pixel tracking
      if (typeof fbq !== 'undefined') {
        fbq('track', 'Contact');
      }
    }
  }

  // ============================================
  // Email Validation Enhancement
  // ============================================
  class EmailValidator {
    static async validateEmail(email) {
      // Basic format check
      if (!config.validationRules.email.pattern.test(email)) {
        return { valid: false, message: 'Invalid email format' };
      }

      // Check for disposable email domains
      const disposableDomains = ['tempmail.com', '10minutemail.com', 'guerrillamail.com'];
      const domain = email.split('@')[1];
      
      if (disposableDomains.includes(domain)) {
        return { valid: false, message: 'Please use a permanent email address' };
      }

      return { valid: true, message: '' };
    }
  }

  // ============================================
  // Spam Protection
  // ============================================
  class SpamProtection {
    constructor(form) {
      this.form = form;
      this.honeypot = this.createHoneypot();
      this.submissionTimes = [];
    }

    createHoneypot() {
      const honeypot = document.createElement('input');
      honeypot.type = 'text';
      honeypot.name = 'website';
      honeypot.style.display = 'none';
      honeypot.tabIndex = -1;
      honeypot.autocomplete = 'off';
      this.form.appendChild(honeypot);
      return honeypot;
    }

    checkHoneypot() {
      return this.honeypot.value === '';
    }

    checkSubmissionRate() {
      const now = Date.now();
      this.submissionTimes = this.submissionTimes.filter(time => now - time < 60000);
      
      if (this.submissionTimes.length >= 3) {
        return false; // Too many submissions
      }

      this.submissionTimes.push(now);
      return true;
    }

    isValid() {
      return this.checkHoneypot() && this.checkSubmissionRate();
    }
  }

  // ============================================
  // Auto-save Draft
  // ============================================
  class DraftManager {
    constructor(formId) {
      this.formId = formId;
      this.storageKey = `contact_form_draft_${formId}`;
      this.autoSaveInterval = null;
    }

    startAutoSave(form) {
      // Load existing draft
      this.loadDraft(form);

      // Auto-save every 30 seconds
      this.autoSaveInterval = setInterval(() => {
        this.saveDraft(form);
      }, 30000);

      // Save on beforeunload
      window.addEventListener('beforeunload', () => {
        this.saveDraft(form);
      });
    }

    saveDraft(form) {
      const draft = {
        name: form.querySelector('[name="name"]').value,
        email: form.querySelector('[name="email"]').value,
        subject: form.querySelector('[name="subject"]').value,
        message: form.querySelector('[name="message"]').value,
        timestamp: Date.now()
      };

      // Only save if there's content
      if (draft.message.trim() || draft.subject.trim()) {
        localStorage.setItem(this.storageKey, JSON.stringify(draft));
      }
    }

    loadDraft(form) {
      const draftJson = localStorage.getItem(this.storageKey);
      
      if (draftJson) {
        try {
          const draft = JSON.parse(draftJson);
          
          // Check if draft is less than 24 hours old
          if (Date.now() - draft.timestamp < 86400000) {
            if (confirm('Would you like to restore your previous draft?')) {
              form.querySelector('[name="name"]').value = draft.name || '';
              form.querySelector('[name="email"]').value = draft.email || '';
              form.querySelector('[name="subject"]').value = draft.subject || '';
              form.querySelector('[name="message"]').value = draft.message || '';
            }
          } else {
            this.clearDraft();
          }
        } catch (error) {
          console.error('Error loading draft:', error);
        }
      }
    }

    clearDraft() {
      localStorage.removeItem(this.storageKey);
      if (this.autoSaveInterval) {
        clearInterval(this.autoSaveInterval);
      }
    }
  }

  // ============================================
  // Initialization
  // ============================================
  function init() {
    const contactForm = new ContactForm('#contact-form');
    
    if (contactForm.form) {
      // Add spam protection
      const spamProtection = new SpamProtection(contactForm.form);
      
      // Add draft management
      const draftManager = new DraftManager('contact-form');
      draftManager.startAutoSave(contactForm.form);
      
      // Clear draft on successful submission
      contactForm.form.addEventListener('submit', (e) => {
        if (contactForm.validateForm() && spamProtection.isValid()) {
          setTimeout(() => {
            draftManager.clearDraft();
          }, 2000);
        }
      });

      console.log('Contact form initialized');
    }
  }

  // Wait for DOM to be ready
  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', init);
  } else {
    init();
  }

})();