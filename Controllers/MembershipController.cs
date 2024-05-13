using Blog.Interfaces;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MembershipController : Controller
    {
        private readonly IMembership _membership;

        public MembershipController(IMembership membership) { 
            _membership = membership;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var allMembership = await _membership.GetAllMembershipAsync();
            return View(allMembership);
        }

        [HttpGet]
        public async Task<IActionResult> Generate([FromServices] IHttpContextAccessor httpContextAccessor) { 
            string code = Guid.NewGuid().ToString();
            string link = HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host.Value + "/register?code=" + code;
            var membership = new Membership
            {
                CreatedDate = DateTime.Now,
                IsEnable = true,
                Code = code,
                Link = link
            };
            await _membership.AddMembershipAsync(membership);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int membershipId) { 
            var current = await _membership.GetMembershipAsync(membershipId);
            if (current != null) {
                await _membership.DeleteMembershipAsync(current);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
