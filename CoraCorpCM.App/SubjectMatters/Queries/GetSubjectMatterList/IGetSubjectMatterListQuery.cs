using System.Collections.Generic;

namespace CoraCorpCM.App.SubjectMatters.Queries.GetSubjectMatterList
{
    public interface IGetSubjectMatterListQuery
    {
        List<SubjectMatterModel> Execute(int museumId);
    }
}
