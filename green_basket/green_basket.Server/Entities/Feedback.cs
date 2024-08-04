using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace green_basket.Server.Entities
{
    public class Feedback
    {
        public int feedback_id { get; set; }
        [ForeignKey("vegetable_id")]
        public int vegetable_id { get; set; }
        [ForeignKey("user_id")]
        public  int user_id { get; set; }
        [Range(1,5,ErrorMessage ="Rating must be between 1 and 5.")]
        public int rating { get; set; }
        [StringLength(100,ErrorMessage ="Comments can't be longer than 100 characters")]
        public string comments { get; set; }
        
        public Feedback()
        {

        }
        public Feedback(int feedback_id, int vegetable_id, int user_id, int rating, string comments)
        {
            this.feedback_id = feedback_id;
            this.vegetable_id = vegetable_id;
            this.user_id = user_id;
            this.rating = rating;
            this.comments = comments;
        }
    }
}
