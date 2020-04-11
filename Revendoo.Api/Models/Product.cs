using System;

namespace Revendo.Api.Models
{
    public class Product : Entity
    {
        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Valor do produto em reais
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Quantidade em estoque do produto
        /// </summary>
        public int AmountStock { get; set; }
        
        /// <summary>
        /// Data de Validade do produto
        /// </summary>
        /// Além disso, ao colocar a interrogação na frente do Datetime, estamos dizendo que esse campo não será obrigatório.
        public DateTime? ExpirationDate { get; set; }
    }
}
