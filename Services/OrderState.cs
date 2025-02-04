using Microsoft.AspNetCore.Components.Web;

namespace BlazingPizza.Services;

public class OrderState
{
    public bool ShowingConfigurePizza { get; private set; }
    public Pizza ConfiguringPizza { get; private set; }
    public Order Order { get; private set; } = new Order();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>()
        };

        ShowingConfigurePizza = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;

        ShowingConfigurePizza = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        Order.Pizzas.Add(ConfiguringPizza);

        ConfiguringPizza = null;

        ShowingConfigurePizza = false;
    }

}
