
using App.Ordering.Api.Core.Data.Entities.SeedWork;

namespace App.Ordering.Api.Core.Data;

public class OrderingStatus : Enumeration
{
    public static OrderingStatus UnPaid = new OrderingStatus(0, "UnPaid");
    public static OrderingStatus Paid = new OrderingStatus(1, "Paid");
    public static IEnumerable<OrderingStatus> List() =>
    new[] { UnPaid, Paid };

    public OrderingStatus(int id, string name) : base(id, name)
    {
    }
    public static OrderingStatus FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new Exception($"Possible values for OrderingStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static OrderingStatus From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new Exception($"Possible values for OrderingStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}