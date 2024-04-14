using BookingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(ContactViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Send email
            var message = new MailMessage
            {
                From = new MailAddress("abdoelbeherey@gmail.com", "Abdo Elbehery") //  application email ex:bookingSys@gmail.com
            };

            message.To.Add("abdoelbeherey@gmail.com"); // Admin email that will recive the message
            message.Subject = model.Subject;
            message.Body = $"From: {model.Name} ({model.Email})\n\n{model.Message}";

            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("abdoelbeherey@gmail.com", "eqww dtuc spxi riql"); // credintial for application email 
                smtpClient.EnableSsl = true;

                try
                {
                    smtpClient.Send(message);
                    return Json(new { success = true, message = "Your message has been sent successfully!" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"Failed to send message. Error: {ex.Message}" });
                }
            }
        }

        return Json(new { success = false, message = "Validation failed. Please check your input." });
    }
}
