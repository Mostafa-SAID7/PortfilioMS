using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfilioMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChatManagementController : Controller
    {
        private readonly IChatService _chatService;

        public ChatManagementController(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _chatService.GetAllMessagesAsync();
            return View(messages);
        }

        [HttpPost]
        public async Task<IActionResult> Reply(int messageId, string reply)
        {
            var message = await _chatService.ReplyToMessageAsync(messageId, reply);
            return Json(new { success = true, message });
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int messageId)
        {
            var result = await _chatService.MarkAsReadAsync(messageId);
            return Json(new { success = result });
        }
    }
}
