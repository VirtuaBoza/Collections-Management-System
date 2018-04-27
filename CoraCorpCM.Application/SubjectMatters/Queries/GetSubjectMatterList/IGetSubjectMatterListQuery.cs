using System.Collections.Generic;

namespace CoraCorpCM.Application.SubjectMatters.Queries.GetSubjectMatterList
{
    public interface IGetSubjectMatterListQuery
    {
        List<SubjectMatterModel> Execute(int museumId);
    }
}
