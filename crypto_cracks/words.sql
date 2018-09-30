create extension if not exists pgcrypto;
drop table if exists words;
create table words(
  id serial primary key,
  word text not null,
  md5 text,
  sha1 text,
  sha256 text
);

COPY words 
FROM '[ABSOLUTE PATH TO]/words.csv' 
WITH DELIMITER ',' HEADER CSV;

update words set
md5 = md5(word), 
sha1 = encode(digest(word, 'sha1'), 'hex'),
sha256 = encode(digest(word, 'sha256'), 'hex');