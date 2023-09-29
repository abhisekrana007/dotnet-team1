﻿using ProjectService.Models;

namespace ProjectService.services
{
    public interface IProposalService
    {

        bool CreateProposal(Proposal proposal);
        bool DeleteProposal(string proposalId);
        bool UpdateProposal(string id,Proposal proposal);
        List<Proposal> GetAllProposalByProjectId(string projectid);
        bool StatusUpdate(string proposalid,string status);

        List<Proposal> GetAllProposal();
         List<Proposal> GetAllProposalByExpertId(string expertid);

    }
}
