

insert into doubles(double_word)
select concat(s1.word,'-',s2.word)
from singles s1
inner join singles s2 on s1.word <> s2.word