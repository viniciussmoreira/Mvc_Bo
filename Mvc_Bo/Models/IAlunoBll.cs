﻿using System.Collections.Generic;

namespace Mvc_Bo.Models
{
    public interface IAlunoBll
    {
        List<Aluno> GetAlunos();
        void IncluirAluno(Aluno aluno);
        void AtualizarAluno(Aluno aluno);
        void DeletarAluno(int id);
    }
}
