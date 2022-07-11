insert ignore into Contents.Sections 
(
    Name, 
    Supertitle, 
    Title, 
    Subtitle, 
    Description, 
    `Key`
)
values
(
    'Services',
    'Tailored for affordability',
    'Choose with confidence',
    'We are always here for you',
    'Our services are designed to make your life easier and more productive. We settle only when you are satisfied',
    'services'
);

select Id into @servicesId
from Contents.Sections
where `Key` = 'services';

insert ignore into Contents.Items
(
    SectionId, 
    Title, 
    Subtitle, 
    Summary, 
    PrimaryCtaText, 
    PrimaryCtaLink
)
values
(
    @servicesId,
    'Boost',
    'Always making you better',
    'We care about your current and future status by providing more feedback to you, so that you can work on them and increase your overall state.',
    'Read more',
    '/service-one'
),
(
    @servicesId,
    'Comparison',
    'Choose with eyes open',
    'Never stop at comparing options with each other. Any option might have its benefits, and its problems. Watch carefully and choose accordingly',
    'See how',
    '/comparison'
),
(
    @servicesId,
    'Continuity',
    'Never stop, keep going',
    'Many things in life are just like waves. They come and go. But we encourage you to think of the ocean itself. It always stays. Stay!',
    'Find techniques',
    '/continuity'
),
(
    @servicesId,
    'Reliance',
    'A true pillar',
    'Trust, is one word. But its meaning is more than a thousand moments that you have experienced personally. Trust, can only be created through time.',
    'Learn more',
    '/reliance'
);