namespace DomainManagment.BlazorUI.Models
{

    public class CustomerVM
    {
        // This property holds the unique identifier for each customer, usually a GUID or another 
        // string that uniquely identifies a customer in the system.
        public string Id { get; set; }

        // This property holds the email address of the customer. In a real-world application, 
        // this might also include validation to ensure that the email format is correct.
        public string Email { get; set; }

        // This property holds the first name of the customer. It is used to personalize 
        // the user interface and communications with the customer.
        public string Firstname { get; set; }

        // This property holds the last name of the customer. Like the first name, it is 
        // used for personalization and may be included in communications and displays.
        public string Lastname { get; set; }

    }

}
