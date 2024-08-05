namespace green_basket.Server.Entities
{
    public class Response
    { 
        public int statusCode {  get; set; }
        public string StatusMessage { get; set; }

        public List<User> listuser { get; set; }

        public User user  { get; set; }
        public  List<Vegetables> listvegetables { get; set; }

        public Vegetables vegetables { get; set; }
        public List<Cart_Order> cartlist { get; set; }
        public Cart_Order  Cart_Order { get; set; }
        public List<Orders> orderlist { get; set; }
        public Orders orders { get; set; }

        public List<Cart_Vegetables> cartvegetableslist { get; set; }
        public Cart_Vegetables cart_Vegetables { get; set; }

        public List<BillDetails> billList { get; set; }
        public  BillDetails billDetails { get;  set; }

        public List<Current_User_Session> userSessionList { get; set; }
        public Current_User_Session current_userSession { get; set; }

        public  List<Feedback> feedbacklist { get; set; }
        public  Feedback feedback { get; set; }



    }
}
