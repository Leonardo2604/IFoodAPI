using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IFoodAPI.Models
{
    public class Order
    {
        /// <summary>
        /// Id de referencia interno
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// Id de referencia do pedido
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; private set; }

        /// <summary>
        /// Extranet Id
        /// </summary>
        [JsonProperty("shortReference")]
        public string ShortReference { get; private set; }

        [JsonProperty("takeOutTimeInSeconds")]
        public int TakeOutTimeInSeconds { get; private set; }

        [JsonProperty("takeOutDateTime")]
        public DateTime TakeOutDateTime { get; private set; }

        /// <summary>
        /// Data e hora de criação do pedido
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Indica se o pedido foi agendado
        /// </summary>
        [JsonProperty("scheduled")]
        public bool Scheduled { get; private set; }

        [JsonProperty("deliveryMethod")]
        public DeliveryMethod DeliveryMethod { get; private set; }

        [JsonProperty("merchant")]
        public Merchant Merchant { get; private set; }

        [JsonProperty("payments")]
        public List<Payment> Payments { get; private set; }

        [JsonProperty("customer")]
        public Customer Customer { get; private set; }

        /// <summary>
        /// Lista de itens que foram pedidos pelo cliente
        /// </summary>
        [JsonProperty("items")]
        public List<OrderItem> Items { get; private set; }

        [JsonProperty("subTotal")]
        public float SubTotal { get; private set; }

        [JsonProperty("totalPrice")]
        public float TotalPrice { get; private set; }

        /// <summary>
        /// Taxa de entrega cobrada
        /// </summary>
        [JsonProperty("deliveryFee")]
        public float DeliveryFee { get; private set; }

        /// <summary>
        /// Endereço de entrega do pedido
        /// </summary>
        [JsonProperty("deliveryAddress")]
        public DeliveryAddress DeliveryAddress { get; private set; }

        /// <summary>
        /// Hora da entrega do pedido
        /// </summary>
        [JsonProperty("deliveryDateTime")]
        public DateTime DeliveryDateTime { get; private set; }

        /// <summary>
        /// Tempo de preparo do pedido em segundos
        /// </summary>
        [JsonProperty("preparationTimeInSeconds")]
        public int PreparationTimeInSeconds { get; private set; }

        /// <summary>
        /// Inicio do preparo
        /// </summary>
        [JsonProperty("preparationStartDateTime")]
        public DateTime PreparationStartDateTime { get; private set; }

        [JsonProperty("localizer")]
        public Localizer Localizer { get; private set; }

        /// <summary>
        /// Indica se o pedido é de teste
        /// </summary>
        [JsonProperty("isTest")]
        public bool IsTest { get; private set; }

        /// <summary>
        /// Descontos oferecido ao cliente pelo IFood ou Restaurante
        /// </summary>
        [JsonProperty("benefits")]
        public List<Benefit> Benefits { get; private set; }

        public Order()
        {

        }

        public Order(
            string id,
            string reference,
            string shortReference,
            int takeOutTimeInSeconds,
            DateTime takeOutDateTime,
            DateTime createdAt,
            bool scheduled,
            DeliveryMethod deliveryMethod,
            Merchant merchant,
            List<Payment> payments,
            Customer customer,
            List<OrderItem> items,
            float subTotal,
            float totalPrice,
            float deliveryFee,
            DeliveryAddress deliveryAddress,
            DateTime deliveryDateTime,
            int preparationTimeInSeconds,
            DateTime preparationStartDateTime,
            Localizer localizer,
            bool isTest,
            List<Benefit> benefits)
        {
            Id = id;
            Reference = reference;
            ShortReference = shortReference;
            TakeOutTimeInSeconds = takeOutTimeInSeconds;
            TakeOutDateTime = takeOutDateTime;
            CreatedAt = createdAt;
            Scheduled = scheduled;
            DeliveryMethod = deliveryMethod;
            Merchant = merchant;
            Payments = payments;
            Customer = customer;
            Items = items;
            SubTotal = subTotal;
            TotalPrice = totalPrice;
            DeliveryFee = deliveryFee;
            DeliveryAddress = deliveryAddress;
            DeliveryDateTime = deliveryDateTime;
            PreparationTimeInSeconds = preparationTimeInSeconds;
            PreparationStartDateTime = preparationStartDateTime;
            Localizer = localizer;
            IsTest = isTest;
            Benefits = benefits;
        }
    }
}
