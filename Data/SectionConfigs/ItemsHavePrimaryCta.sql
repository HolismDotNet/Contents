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
    'Items have primary CTA',
    'Users can add CTA. They can specify CTA text and link.',
    'ItemsHavePrimaryCta'
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
        where `Key` = 'ItemsHavePrimaryCta'
    )
);