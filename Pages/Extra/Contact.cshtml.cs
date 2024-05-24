using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
#nullable disable

namespace optimization.Pages.Extra
{

    public class ContactModel : PageModel
    {
        [BindProperty]
        public Message Message { set; get; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                string text = string.Format(@"
                        Dear Vilinze,
                        
                        {0}
                        
                        Sincerely,

                        {1}
                        {2}

                ", Message.content, Message.Name, Message.phonenumber);
                //string html = String.Format("Your beloved {0} is contacting", Message.Name);

                //html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + message.Body);

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("hammam.abosaleh@outlook.com");
                msg.To.Add(new MailAddress(Message.Email));
                msg.Subject = "Get In Touch With Vilinze";
                msg.Body = text;
                //msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                //msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("hammam.abosaleh@outlook.com", "password");
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }

    public class Message
    {
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to provide a vaild email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to provide a vaild phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        [MinLength(11, ErrorMessage = "Please provide an 11 digit phone number")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "You need to provide a vaild address")]
        [DataType(DataType.EmailAddress)]
        public string content { get; set; }

    }
}
