insert ignore into Configuration.ConfigItems
(
    ConfigTypeId,
    Name,
    Description,
    `Key`
)
values
(
    (
        select Id
        from Configuration.ConfigTypes 
        where `Key` = 'Boolean'
    ),
    'Has supertitle',
    'Users can provide a supertitle for this section. Supertitle is what comes before title.',
    'HasSupertitle'
);

insert ignore into Configuration.EntityConfigItems
(
    EntityTypeGuid,
    ConfigItemId
)
values
(
    (
        select Guid
        from Entities.EntityTypes
        where Name = 'section'
    ),
    (
        select Id 
        from Configuration.ConfigItems
        where `Key` = 'HasSupertitle'
    )
);