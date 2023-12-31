﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace IatModels
{
    public class Quizz
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.Now;
        public DateTime FinishedAt { get; set; }
        public List<Question> Questions { get; set; } = new ();
        [DisplayName("Pontuação")]
        public double Score { get; set; }        
        public List<Answer> Answers { get; set; } = new ();
        [DisplayName("Nome do Estudante")]
        public string? NameOfStudent { get; set; }
        [DisplayName("Número de Questões")]
        public int NumberOfQuestions { get; set; }
        [DisplayName("% do Total de Pontos")]
        public double ScoreRatio { get; set; }
        public int Rights { get; set; }
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
