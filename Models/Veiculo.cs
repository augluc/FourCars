using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourCars.Models
{
    [Table("TB_VEICULO")]
    public class Veiculo
    {
        [Column("Id"), HiddenInput]
        [Required]
        public int VeiculoId { get; set; }
        [Required]
        public Categoria Categoria { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        [MaxLength(55)]
        public string Modelo { get; set; }
        [Required]
        public Marca Marca { get; set; }


    }

    public enum Categoria
    {
        Novo, Usado, Seminovo
    }

    public enum Marca
    {
        Abarth,
        AlfaRomeo,
        AstonMartin,
        Audi,
        Bentley,
        BMW,
        Bugatti,
        Cadillac,
        Chevrolet,
        Chrysler,
        Citroën,
        Dacia,
        Daewoo,
        Daihatsu,
        Dodge,
        Donkervoort,
        DS,
        Ferrari,
        Fiat,
        Fisker,
        Ford,
        Honda,
        Hummer,
        Hyundai,
        Infiniti,
        Iveco,
        Jaguar,
        Jeep,
        Kia,
        KTM,
        Lada,
        Lamborghini,
        Lancia,
        LandRover,
        Landwind,
        Lexus,
        Lotus,
        Maserati,
        Maybach,
        Mazda,
        McLaren,
        MercedesBenz,
        MG,
        Mini,
        Mitsubishi,
        Morgan,
        Nissan,
        Opel,
        Peugeot,
        Porsche,
        Renault,
        RollsRoyce,
        Rover,
        Saab,
        Seat,
        Skoda,
        Smart,
        SsangYong,
        Subaru,
        Suzuki,
        Tesla,
        Toyota,
        Volkswagen,
        Volvo,
        Outro
    }


}
