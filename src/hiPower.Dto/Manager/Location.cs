namespace hiPower.Dto.Manager;

public record class Location(string Id, string Name, string Address, string City, string PostalCode, string Region, string Country, string Description): BaseDto(Id);

