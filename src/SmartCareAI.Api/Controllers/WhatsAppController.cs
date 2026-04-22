using Microsoft.AspNetCore.Mvc;

namespace SmartCareAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WhatsAppController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public WhatsAppController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // ميتة بتستخدم الـ GET للتحقق من الـ Webhook أول مرة (Verification)
    [HttpGet]
    public IActionResult VerifyWebhook(
        [FromQuery(Name = "hub.mode")] string mode,
        [FromQuery(Name = "hub.verify_token")] string token,
        [FromQuery(Name = "hub.challenge")] string challenge)
    {
        var myVerifyToken = "SmartCare_Verify_Token_2026"; // ده رقم سري إحنا اللي بنألفه

        if (mode == "subscribe" && token == myVerifyToken)
        {
            return Ok(challenge);
        }

        return Forbid();
    }

    // ميتة بتستخدم الـ POST عشان تبعت رسايل المرضى الفعلية
    [HttpPost]
    public async Task<IActionResult> ReceiveMessage()
    {
        // هنا هنستقبل الرسالة.. بس دلوقتي هنطبع "رسالة وصلت" في الـ Log
        Console.WriteLine("--- New WhatsApp Message Received! ---");
        
        return Ok();
    }
}