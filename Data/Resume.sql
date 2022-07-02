select Guid into @pageEntityTypeGuid
from Entities.EntityTypes
where Name = 'page';

insert ignore into Taxonomy.Hierarchies
(
    EntityTypeGuid,
    Title,
    Description,
    `Key`,
    Slug
)
values
(
    @pageEntityTypeGuid,
    'Resume',
    'Here you can find our resume. We have accomplished many successful projects. Who knows, maybe your next successful project would be done by us.',
    'resume-page',
    'resume'
);

select Guid into @resumePageGuid
from Taxonomy.Hierarchies
where `Key` = 'resume-page';

insert ignore into Contents.Pages
(
    HierarchyGuid
)
values
(
    @resumePageGuid
);

select Id into @pageId
from Contents.Pages
where HierarchyGuid = 
(
    select Guid
    from Taxonomy.Hierarchies
    where `Key` = 'resume-page'
);

insert ignore into Contents.PageContents
(
    Id,
    Content
)
values
(
    @pageId,
    '[{"type":"heading-two","children":[{"text":"Who are we?"}]},{"type":"paragraph","children":[{"text":"We are a team of experts, working with the best material to make sure you stay confident about the future of your project."}]},{"type":"paragraph","children":[{"text":"Our team is made of two groups:"}]},{"type":"numbered-list","children":[{"type":"list-item","children":[{"text":"Engineers"}]},{"type":"list-item","children":[{"text":"Support staff"}]}]},{"type":"paragraph","children":[{"text":"Our engineering group makes sure that the design is resilient no matter how catastrophic the events might be."}]},{"type":"paragraph","children":[{"text":"Our support staff is here for you 24/7 to make sure you meet your needs and your concerns are considered."}]},{"type":"heading-two","children":[{"text":"What do we do?"}]},{"type":"paragraph","children":[{"text":"We provide analysis and design for your projects."}]},{"type":"paragraph","children":[{"text":"Just tell us your dream or idea, and let us build it in front of your eyes."}]}]'
)