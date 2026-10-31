using IT3047C_FinalProject.Migrations;
using IT3047C_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT3047C_FinalProject.Controllers
{
    [Route("/team-members")]
    public class TeamMemberController : Controller
    {
        private readonly Team10Context _context;

        public TeamMemberController(Team10Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamMembers()
        {
            var model = await _context.TeamMembers.ToListAsync();
            return View("TeamMemberViewModel", model);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new TeamMember());
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return View(teamMember);
            }

            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(GetTeamMembers));
        }

        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember is null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return View(teamMember);
            }

            var existingMember = await _context.TeamMembers.FindAsync(id);
            if (existingMember is null)
            {
                return NotFound();
            }

            existingMember.Name = teamMember.Name;
            existingMember.MNumber = teamMember.MNumber;
            existingMember.Email = teamMember.Email;
            existingMember.GitHubUsername = teamMember.GitHubUsername;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(GetTeamMembers));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var existingMember = await _context.TeamMembers.FindAsync(id);
            if (existingMember is null)
            {
                return NotFound(new { message = "Team member not found." });
            }

            existingMember.Name = teamMember.Name;
            existingMember.MNumber = teamMember.MNumber;
            existingMember.Email = teamMember.Email;
            existingMember.GitHubUsername = teamMember.GitHubUsername;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Team member updated." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember is null)
            {
                return NotFound(new { message = "Team member not found." });
            }

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Team member deleted." });
        }

        [HttpPost("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFromList(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember is null)
            {
                return NotFound();
            }

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Team member deleted successfully.";
            return RedirectToAction(nameof(GetTeamMembers));
        }
    }
}
