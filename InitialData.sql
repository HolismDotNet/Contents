insert ignore into Texts 
(
    Title,
    `Value`,
    `Key`
)
values
(
    'Brand', 
    'Brand', 
    'brand'
),
(
    'Copyright', 
    'Copyright, All rights reserved', 
    'copyright'
);

select Id into @heroId
from Sections
where `Key` = 'hero';

insert into Actions
(
    SectionId,
    CtaText,
    CtaLink
)
values
(
    @heroId,
    'Start today',
    '/start'
),
(
    @heroId,
    'Watch how',
    '/watch'
);

select Id into @servicesId
from Sections
where `Key` = 'services';

insert ignore into Items(SectionId, Title, Subtitle, Summary, CtaLink, CtaText)
values
(@servicesId, 'Boost', 'Always making you better', 'We care about your current and future status by providing more feedback to you, so that you can work on them and increase your overall state.', '/service-one', 'Read more'),
(@servicesId, 'Comparison', 'Choose with eyes open', 'Never stop at comparing options with each other. Any option might have its benefits, and its problems. Watch carefully and choose accordingly', '/comparison', 'See how'),
(@servicesId, 'Continuity', 'Never stop, keep going', 'Many things in life are just like waves. They come and go. But we encourage you to think of the ocean itself. It always stays. Stay!', '/continuity', 'Find techniques'),
(@servicesId, 'Reliance', 'A true pillar', 'Trust, is one word. But its meaning is more than a thousand moments that you have experienced personally. Trust, can only be created through time.', '/reliance', 'Learn more');