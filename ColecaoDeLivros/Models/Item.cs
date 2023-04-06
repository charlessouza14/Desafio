﻿using ColecaoDeLivros.DTO;
using System.Reflection.Metadata;

namespace ColecaoDeLivros.Models
{
    public class Item
    {
        public int Id { get; set; }     
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }       
        public DateTime UltimaAtualizacao { get; set; }         
        public Contato Contato { get; set; }
        
        public Item()
        {
            UltimaAtualizacao = DateTime.Now;     
            Status = "Disponível";
        }           
       
        public ValidadorDeItem EhValido()
        {
            if (string.IsNullOrWhiteSpace(this.Nome))
                return new ValidadorDeItem(false, "Por favor digite um nome válido!");
           
            if (string.IsNullOrWhiteSpace(this.Tipo))
                return new ValidadorDeItem(false, "Por favor digite um tipo válido!");


            else
                return new ValidadorDeItem(true, "Criado com sucesso!");
        }
               
     
    }
    
}
