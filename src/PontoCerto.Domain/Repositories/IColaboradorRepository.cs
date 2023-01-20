﻿using PontoCerto.Domain.Entities;

namespace PontoCerto.Domain.Repositories;

public interface IColaboradorRepository
{
    Task<IEnumerable<Colaborador>> Obter(string empresaId);
}