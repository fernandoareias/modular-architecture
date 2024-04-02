
using Atividade02.Proposals.Domain.Proposals;
using MongoDB.Driver;

namespace Notification.Worker.Data.Builders;

public class ProposalGetAllBuilder
{
    private List<FilterDefinition<Proposal>> _filters = new List<FilterDefinition<Proposal>>();

    public ProposalGetAllBuilder AddCPF(string? cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf)) return this;

        _filters.Add(Builders<Proposal>.Filter.Eq("Proponent.CPF.Number", cpf));

        return this;
    }

    public ProposalGetAllBuilder AddCNPJ(string? cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj)) return this;

        _filters.Add(Builders<Proposal>.Filter.Eq("Store.cnpj", cnpj));

        return this;
    }

    public FilterDefinition<Proposal> Build()
        => Builders<Proposal>.Filter.And(_filters);
}