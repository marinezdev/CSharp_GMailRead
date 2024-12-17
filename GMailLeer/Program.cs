//using System.Net.Http.Headers;
//using System.Text;
//using System.Xml;

//try
//{
//    const string emailAddress = "rmf.asae.dev@gmail.com";
//    // App Password, not password
//    // See: https://support.google.com/accounts/answer/185833?hl=en
//    const string appPassword = "tu password";

//    string response;
//    string title;
//    string summary;
//    XmlDocument xmlDocument = new XmlDocument();

//    HttpClient httpClient = new HttpClient();

//    // Logging in Gmail server to get data
//    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{emailAddress}:{appPassword}")));

//    // Reading data and converting to string
//    response = await httpClient.GetStringAsync(@"https://mail.google.com/mail/feed/atom");

//    // Remove XML namespace to simplify parsing/selecting nodes
//    response = response.Replace(@"<feed version=""0.3"" xmlns=""http://purl.org/atom/ns#"">", @"<feed>");

//    // Loading into an XML so we can get information easily
//    xmlDocument.LoadXml(response);

//    // Amount of emails
//    string nr = xmlDocument.SelectSingleNode(@"/feed/fullcount").InnerText;

//    // Reading the title and the summary for every email
//    foreach (XmlNode node in xmlDocument.SelectNodes(@"/feed/entry"))
//    {
//        title = node.SelectSingleNode("title").InnerText;
//        summary = node.SelectSingleNode("summary").InnerText;

//        Console.WriteLine($"> {title}");
//        Console.WriteLine($"{summary}");
//        Console.WriteLine();
//    }
//}
//catch (HttpRequestException ex)
//{
//    Console.WriteLine($"Error al obtener los correos: {ex.Message}");
//    Console.WriteLine($"Estado HTTP: {ex.StatusCode}");
//}

using GMailLeer;

var mailRepository = new MailRepository("imap.gmail.com", 993, true, "tucorreo@gmail.com", "tupassword");
//var allEmails = mailRepository.GetAllMails();
var allEmails = mailRepository.GetUnreadMails();

foreach (var email in allEmails)
{
    Console.WriteLine(email);
}

//Assert.IsTrue(allEmails.ToList().Any());