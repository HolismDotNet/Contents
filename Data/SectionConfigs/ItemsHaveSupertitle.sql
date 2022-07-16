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
    'Items have supertitle',
    'Users can provide a supertitle for each item of a section. Supertitle is what comes before title.',
    'ItemsHaveSupertitle'
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
        where `Key` = 'ItemsHaveSupertitle'
    )
);