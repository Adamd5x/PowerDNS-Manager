namespace hiPower.Entity;

public class DataCenter : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public ICollection<ServiceDetails> Servers { get; set; }
}
