using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Fotballer : AuditableEntity
    {
     
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(100)]
        public string ClubName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int? ClubId { get; set; }
        public Club Club { get; set; }

        public Fotballer()
        {
            
        }
        public Fotballer(int id, string name, string surname, string clubName, int age, DateTime dateOfBirth, int goals, int assists)
        {
            ID = id;
            Name = name;
            ClubName = clubName;
            Age = age;
            DateOfBirth = dateOfBirth;
            Goals = goals;
            Assists = assists;
            Surname = surname;
        }
    }
}
