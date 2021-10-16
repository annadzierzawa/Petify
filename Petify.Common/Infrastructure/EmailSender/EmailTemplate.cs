namespace Petify.Common.Infrastructure.EmailSender
{
    public class EmailTemplate
    {
        public string PreferredLanguage { get; set; }
        public string EnglishSubject { private get; set; }
        public string PolishSubject { private get; set; }
        public string EnglishMessage { private get; set; }
        public string PolishMessage { private get; set; }

        private string PolishLanguage => "pl";

        public EmailTemplate(string preferredLanguage, string englishSubject, string polishSubject, string englishMessage, string polishMessage)
        {
            PreferredLanguage = preferredLanguage;
            EnglishSubject = englishSubject;
            PolishSubject = polishSubject;
            EnglishMessage = englishMessage;
            PolishMessage = polishMessage;
        }

        public string GetMessage => PreferredLanguage == PolishLanguage
            ? PolishMessage
            : EnglishMessage;

        public string GetSubject => PreferredLanguage == PolishLanguage
            ? PolishSubject
            : EnglishSubject;
    }
}
