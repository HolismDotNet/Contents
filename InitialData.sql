insert ignore into Texts (Title, `Value`, `Key`)
values
('Brand', 'Brand', 'brand'),
('Copyright', 'Copyright, All rights reserved', 'copyright');

insert ignore into Sections (Name, Supertitle, Title, Subtitle, Description, `Key`)
values
('Services', 'Tailored for affordability', 'Choose with confidence', 'We are always here for you', 'Our services are designed to make your life easier and more productive. We settle only when you are satisfied', 'services'),
('Testimonials', null, 'See what others say', 'Our reputation is our client''s trust', null, 'testimonials');

select Id into @servicesId
from Sections
where `Key` = 'services';

insert ignore into Items(SectionId, Title, Subtitle, Summary, CtaLink, CtaText)
values
(@servicesId, 'Boost', 'Always making you better', 'We care about your current and future status by providing more feedback to you, so that you can work on them and increase your overall state.', '/service-one', 'Read more'),
(@servicesId, 'Comparison', 'Choose with eyes open', 'Never stop at comparing options with each other. Any option might have its benefits, and its problems. Watch carefully and choose accordingly', '/comparison', 'See how'),
(@servicesId, 'Continuity', 'Never stop, keep going', 'Many things in life are just like waves. They come and go. But we encourage you to think of the ocean itself. It always stays. Stay!', '/continuity', 'Find techniques'),
(@servicesId, 'Reliance', 'A true pillar', 'Trust, is one word. But its meaning is more than a thousand moments that you have experienced personally. Trust, can only be created through time.', '/reliance', 'Learn more');