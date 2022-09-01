namespace mswebapiserver.DTOs
{
    public class AddressDetailsDTO
    {
        public string? AddressType { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int PinCode { get; set; }

    }
}
