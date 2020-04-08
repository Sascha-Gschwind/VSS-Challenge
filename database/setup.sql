-- Schema
create table items(
	id serial PRIMARY KEY,
	description text NOT NULL
);

-- Inserts
insert into items (description) values ('Milch');
insert into items (description) values ('Brot');
insert into items (description) values ('Butter');