namespace BLL.Models.MainPage
{
    public class AchievementModel : BaseModel
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
    }
}
