/**
 * Portfolio Website - Main Site JavaScript
 * Handles global functionality and initialization
 */

(function() {
  'use strict';

  // ============================================
  // Constants
  // ============================================
  const SCROLL_THRESHOLD = 100;
  const MOBILE_BREAKPOINT = 768;
  const DEBOUNCE_DELAY = 250;

  // ============================================
  // DOM Elements
  // ============================================
  const elements = {
    navbar: document.querySelector('.navbar'),
    mobileMenuToggle: document.querySelector('.mobile-menu-toggle'),
    mobileMenu: document.querySelector('.mobile-menu'),
    navLinks: document.querySelectorAll('.nav-link'),
    scrollToTopBtn: document.querySelector('.scroll-to-top'),
    lazyImages: document.querySelectorAll('img[data-src]'),
    animatedElements: document.querySelectorAll('[data-animate]')
  };

  // ============================================
  // Utility Functions
  // ============================================

  /**
   * Debounce function to limit execution rate
   */
  function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
      const later = () => {
        clearTimeout(timeout);
        func(...args);
      };
      clearTimeout(timeout);
      timeout = setTimeout(later, wait);
    };
  }

  /**
   * Throttle function to limit execution frequency
   */
  function throttle(func, limit) {
    let inThrottle;
    return function(...args) {
      if (!inThrottle) {
        func.apply(this, args);
        inThrottle = true;
        setTimeout(() => inThrottle = false, limit);
      }
    };
  }

  /**
   * Check if element is in viewport
   */
  function isInViewport(element, offset = 0) {
    const rect = element.getBoundingClientRect();
    return (
      rect.top >= 0 - offset &&
      rect.left >= 0 &&
      rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) + offset &&
      rect.right <= (window.innerWidth || document.documentElement.clientWidth)
    );
  }

  /**
   * Smooth scroll to element
   */
  function smoothScrollTo(target, duration = 800) {
    const targetElement = typeof target === 'string' ? document.querySelector(target) : target;
    if (!targetElement) return;

    const targetPosition = targetElement.getBoundingClientRect().top + window.pageYOffset;
    const startPosition = window.pageYOffset;
    const distance = targetPosition - startPosition;
    const startTime = performance.now();

    function animation(currentTime) {
      const elapsed = currentTime - startTime;
      const progress = Math.min(elapsed / duration, 1);
      const easeInOutCubic = progress < 0.5
        ? 4 * progress * progress * progress
        : 1 - Math.pow(-2 * progress + 2, 3) / 2;

      window.scrollTo(0, startPosition + distance * easeInOutCubic);

      if (elapsed < duration) {
        requestAnimationFrame(animation);
      }
    }

    requestAnimationFrame(animation);
  }

  // ============================================
  // Navbar Functionality
  // ============================================

  /**
   * Handle navbar scroll effect
   */
  function handleNavbarScroll() {
    if (window.scrollY > SCROLL_THRESHOLD) {
      elements.navbar?.classList.add('scrolled');
    } else {
      elements.navbar?.classList.remove('scrolled');
    }
  }

  /**
   * Handle active nav link based on scroll position
   */
  function updateActiveNavLink() {
    const sections = document.querySelectorAll('section[id]');
    const scrollPosition = window.scrollY + 100;

    sections.forEach(section => {
      const sectionTop = section.offsetTop;
      const sectionHeight = section.offsetHeight;
      const sectionId = section.getAttribute('id');

      if (scrollPosition >= sectionTop && scrollPosition < sectionTop + sectionHeight) {
        elements.navLinks.forEach(link => {
          link.classList.remove('active');
          if (link.getAttribute('href') === `#${sectionId}`) {
            link.classList.add('active');
          }
        });
      }
    });
  }

  /**
   * Initialize mobile menu
   */
  function initMobileMenu() {
    if (!elements.mobileMenuToggle || !elements.mobileMenu) return;

    elements.mobileMenuToggle.addEventListener('click', function() {
      this.classList.toggle('active');
      elements.mobileMenu.classList.toggle('active');
      document.body.classList.toggle('menu-open');
    });

    // Close menu when clicking on a link
    elements.navLinks.forEach(link => {
      link.addEventListener('click', () => {
        elements.mobileMenuToggle?.classList.remove('active');
        elements.mobileMenu?.classList.remove('active');
        document.body.classList.remove('menu-open');
      });
    });

    // Close menu when clicking outside
    document.addEventListener('click', (e) => {
      if (!elements.mobileMenu?.contains(e.target) && 
          !elements.mobileMenuToggle?.contains(e.target)) {
        elements.mobileMenuToggle?.classList.remove('active');
        elements.mobileMenu?.classList.remove('active');
        document.body.classList.remove('menu-open');
      }
    });
  }

  // ============================================
  // Smooth Scrolling
  // ============================================

  /**
   * Initialize smooth scrolling for anchor links
   */
  function initSmoothScrolling() {
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
      anchor.addEventListener('click', function(e) {
        const href = this.getAttribute('href');
        if (href === '#') return;

        e.preventDefault();
        smoothScrollTo(href);

        // Update URL without jumping
        if (history.pushState) {
          history.pushState(null, null, href);
        }
      });
    });
  }

  // ============================================
  // Scroll to Top Button
  // ============================================

  /**
   * Handle scroll to top button visibility
   */
  function handleScrollToTop() {
    if (window.scrollY > 300) {
      elements.scrollToTopBtn?.classList.add('visible');
    } else {
      elements.scrollToTopBtn?.classList.remove('visible');
    }
  }

  /**
   * Initialize scroll to top button
   */
  function initScrollToTop() {
    if (!elements.scrollToTopBtn) return;

    elements.scrollToTopBtn.addEventListener('click', () => {
      window.scrollTo({
        top: 0,
        behavior: 'smooth'
      });
    });
  }

  // ============================================
  // Lazy Loading Images
  // ============================================

  /**
   * Initialize lazy loading for images
   */
  function initLazyLoading() {
    if ('IntersectionObserver' in window) {
      const imageObserver = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
          if (entry.isIntersecting) {
            const img = entry.target;
            const src = img.getAttribute('data-src');
            
            if (src) {
              img.src = src;
              img.removeAttribute('data-src');
              img.classList.add('loaded');
            }
            
            observer.unobserve(img);
          }
        });
      }, {
        rootMargin: '50px'
      });

      elements.lazyImages.forEach(img => imageObserver.observe(img));
    } else {
      // Fallback for browsers that don't support IntersectionObserver
      elements.lazyImages.forEach(img => {
        const src = img.getAttribute('data-src');
        if (src) {
          img.src = src;
          img.removeAttribute('data-src');
        }
      });
    }
  }

  // ============================================
  // Scroll Animations
  // ============================================

  /**
   * Initialize scroll animations
   */
  function initScrollAnimations() {
    if ('IntersectionObserver' in window) {
      const animationObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
          if (entry.isIntersecting) {
            const element = entry.target;
            const animationType = element.getAttribute('data-animate');
            const delay = element.getAttribute('data-delay') || 0;

            setTimeout(() => {
              element.classList.add('animated', animationType);
            }, delay);

            animationObserver.unobserve(element);
          }
        });
      }, {
        threshold: 0.15,
        rootMargin: '0px 0px -50px 0px'
      });

      elements.animatedElements.forEach(el => animationObserver.observe(el));
    }
  }

  // ============================================
  // Form Validation
  // ============================================

  /**
   * Initialize form validation
   */
  function initFormValidation() {
    const forms = document.querySelectorAll('form[data-validate]');

    forms.forEach(form => {
      form.addEventListener('submit', function(e) {
        if (!form.checkValidity()) {
          e.preventDefault();
          e.stopPropagation();
        }
        form.classList.add('was-validated');
      });

      // Real-time validation
      const inputs = form.querySelectorAll('input, textarea, select');
      inputs.forEach(input => {
        input.addEventListener('blur', function() {
          if (this.value) {
            this.classList.add('touched');
            validateField(this);
          }
        });

        input.addEventListener('input', function() {
          if (this.classList.contains('touched')) {
            validateField(this);
          }
        });
      });
    });
  }

  /**
   * Validate individual form field
   */
  function validateField(field) {
    const isValid = field.checkValidity();
    const errorElement = field.parentElement.querySelector('.invalid-feedback');

    if (!isValid) {
      field.classList.add('is-invalid');
      field.classList.remove('is-valid');
      if (errorElement) {
        errorElement.textContent = field.validationMessage;
      }
    } else {
      field.classList.remove('is-invalid');
      field.classList.add('is-valid');
    }
  }

  // ============================================
  // Tooltips
  // ============================================

  /**
   * Initialize tooltips
   */
  function initTooltips() {
    const tooltipTriggers = document.querySelectorAll('[data-tooltip]');

    tooltipTriggers.forEach(trigger => {
      const tooltipText = trigger.getAttribute('data-tooltip');
      const tooltip = document.createElement('div');
      tooltip.className = 'tooltip';
      tooltip.textContent = tooltipText;
      tooltip.style.position = 'absolute';
      tooltip.style.display = 'none';

      document.body.appendChild(tooltip);

      trigger.addEventListener('mouseenter', function(e) {
        const rect = this.getBoundingClientRect();
        tooltip.style.display = 'block';
        tooltip.style.left = rect.left + rect.width / 2 - tooltip.offsetWidth / 2 + 'px';
        tooltip.style.top = rect.top - tooltip.offsetHeight - 10 + 'px';
      });

      trigger.addEventListener('mouseleave', function() {
        tooltip.style.display = 'none';
      });
    });
  }

  // ============================================
  // Loading State
  // ============================================

  /**
   * Remove loading state when page is fully loaded
   */
  function removeLoadingState() {
    const loader = document.querySelector('.page-loader');
    if (loader) {
      loader.classList.add('fade-out');
      setTimeout(() => {
        loader.remove();
      }, 500);
    }
    document.body.classList.add('loaded');
  }

  // ============================================
  // Performance Monitoring
  // ============================================

  /**
   * Log page load performance
   */
  function logPerformance() {
    if (window.performance && window.performance.timing) {
      window.addEventListener('load', () => {
        setTimeout(() => {
          const perfData = window.performance.timing;
          const pageLoadTime = perfData.loadEventEnd - perfData.navigationStart;
          console.log('Page Load Time:', pageLoadTime + 'ms');
        }, 0);
      });
    }
  }

  // ============================================
  // Event Listeners
  // ============================================

  /**
   * Initialize all event listeners
   */
  function initEventListeners() {
    // Scroll events
    window.addEventListener('scroll', throttle(() => {
      handleNavbarScroll();
      updateActiveNavLink();
      handleScrollToTop();
    }, 100));

    // Resize events
    window.addEventListener('resize', debounce(() => {
      // Handle responsive changes
    }, DEBOUNCE_DELAY));

    // Page visibility
    document.addEventListener('visibilitychange', () => {
      if (document.hidden) {
        console.log('Page is hidden');
      } else {
        console.log('Page is visible');
      }
    });
  }

  // ============================================
  // Initialization
  // ============================================

  /**
   * Initialize all modules
   */
  function init() {
    // Wait for DOM to be ready
    if (document.readyState === 'loading') {
      document.addEventListener('DOMContentLoaded', init);
      return;
    }

    console.log('Portfolio Website Initialized');

    // Initialize modules
    handleNavbarScroll();
    initMobileMenu();
    initSmoothScrolling();
    initScrollToTop();
    initLazyLoading();
    initScrollAnimations();
    initFormValidation();
    initTooltips();
    initEventListeners();
    
    // Log performance in development
    if (window.location.hostname === 'localhost') {
      logPerformance();
    }
  }

  // Remove loading state when page is fully loaded
  window.addEventListener('load', removeLoadingState);

  // Start initialization
  init();

  // ============================================
  // Public API
  // ============================================

  window.Portfolio = {
    smoothScrollTo,
    debounce,
    throttle,
    isInViewport
  };

})();