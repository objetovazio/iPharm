using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class Order
    {
        public Order() { }

        public Order(Person person, Company company)
        {
            this.Company = company;
            this.OrderStatus = EnumOrderStatus.Carrinho;
            this.ItemsOrder = new List<ItemOrder>();
            this.Person = person;
        }

        public int Id { get; set; }
        public decimal ValueOrder { get; set; }
        public EnumOrderStatus OrderStatus { get; set; }

        public virtual Address Address { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual Person Person { get; set; }
        public List<ItemOrder> ItemsOrder { get; set; }
        public virtual Review Review { get; set; }
    }

    public enum EnumOrderStatus
    {
        Cancelado = 0,
        Carrinho = 1,
        Solicitado = 2,
        Confirmado = 3,
        ProntoParaEnvio = 4,
        Enviado = 5,
        Entregue = 6
    }
}
