--select e.Code + ';' + e.Name + ';' + d.Name + ';' + d2.Name as data
--from ZlEmployee as e,
--ZlDept as d,
--ZlDept as d2
--where e.Code like '%30008%' 
----and CAST(SUBSTRING(e.Code,CHARINDEX('-',e.Code)+1,LEN(e.Code)) AS int) = 30008 
--and e.Dept = d.Code and  d2.Code = SUBSTRING( e.Dept, 1, 3 )


--CONVERT(date,att_date) <= '2022-06-01' 
--select distinct pers_person_pin from att_transaction 
--where CONVERT(date,att_date) <= '2022-06-01' and CONVERT(date,att_date) >= '2022-05-31'
--declare @starttime Time

SELECT distinct a.pers_person_pin as Code, a.att_date as Date,a.att_datetime as TimeIN, d.att_datetime as TimeOUT
FROM att_transaction as a,
att_transaction as d
where a.att_datetime = (select min(b.att_datetime) from att_transaction as b
where b.pers_person_pin = a.pers_person_pin
and (b.device_sn = '4879202300002' or b.device_sn = '4879202300002') and (DATEDIFF(MINUTE,b.att_datetime, a.att_datetime) <= 5)) 
and d.att_datetime = (select max(c.att_datetime) from att_transaction as c
where c.pers_person_pin = a.pers_person_pin
and c.device_sn = '4879202300009' and (DATEDIFF(MINUTE,a.att_datetime, c.att_datetime) <= 59))
and a.att_datetime < d.att_datetime
and a.att_date <= '2022-06-01' and a.att_date >= '2022-06-01'
order by a.att_datetime desc
 

 
 )

--WITH cteIN AS (
--    SELECT pers_person_pin as ID, DATEPART(MI, att_datetime) as HH, max(att_datetime) as TimeIN
--	from att_transaction where att_state = '0' and (DATEPART(MI,att_datetime) between (DATEPART(MI,att_datetime) - 1) and (DATEPART(MI,att_datetime) + 1)) 
--	group by pers_person_pin, DATEPART(MI, att_datetime)) 
--,cteOUT AS (
--SELECT pers_person_pin as ID, DATEPART(MI, att_datetime) as HH, max(att_datetime) as TimeOut
--	from att_transaction where att_state = '255' and (DATEPART(MI,att_datetime) between (DATEPART(MI,att_datetime) - 1) and (DATEPART(MI,att_datetime) + 1)) 
--	group by pers_person_pin, DATEPART(MI, att_datetime))
--SELECT a.pers_person_pin as Code, a.att_datetime as TimeIN, b.att_datetime as TimeOUT
--from att_transaction as a
--Right join att_transaction b ON b.pers_person_pin = a.pers_person_pin
--where a.att_datetime IN ( select TimeIN from cteIN )
--and b.att_datetime IN ( select TimeOut from cteOUT ) 
--and DATEDIFF(HH, a.att_datetime, b.att_datetime) <= 1 and (DATEDIFF(MI, a.att_datetime, b.att_datetime) between 1 and 30) and CONVERT(datetime,a.att_datetime) < CONVERT(datetime,b.att_datetime)
--and CONVERT(date,a.att_datetime) = '2022-06-01' and a.pers_person_pin = '16172'
--order by a.att_datetime desc 


/****** Script for SelectTopNRows command from SSMS  ******/
with cte as (
SELECT a.id, a.pers_person_pin, a.att_datetime, a.device_sn
  FROM [ZKBioAccess].[dbo].[att_transaction] a
  JOIN [ZKBioAccess].[dbo].[att_transaction] b ON b.id =
  (
  select TOP 1 id from att_transaction
  where pers_person_pin = '947' and att_datetime > '2022-06-02 00:00:00' order by att_datetime asc
  )
  where a.pers_person_pin = '947' and a.att_date >= '2022-06-01' and a.att_date <= '2022-06-02'
  )
  select row_number() OVER (ORDER BY att_datetime asc) ID, pers_person_pin, att_datetime, device_sn, lead(device_sn) OVER (order by att_datetime) as nextDevice, lag(device_sn) OVER (order by att_datetime) as prevDevice 
    into #MyTemp 
	from cte;
	select * 
	into #MyTemp2
	from (
  select ID, pers_person_pin, att_datetime, device_sn
  from #MyTemp
  where device_sn = '4879202300002' and nextDevice = '4879202300009' 
  UNION ALL
  select ID, pers_person_pin, att_datetime, device_sn
  from #MyTemp
  where device_sn = '4879202300009' and prevDevice = '4879202300002'
  ) t;

  select a.pers_person_pin, a.att_datetime as TimeIN, b.att_datetime as TimeOUT
  from #MyTemp2 a,
  #MyTemp2 b where a.device_sn = '4879202300002' and b.device_sn = '4879202300009' and b.ID = (a.ID + 1) and a.pers_person_pin = b.pers_person_pin
  order by a.att_datetime desc

  drop table #MyTemp
  drop table #MyTemp2

  select distinct pers_person_pin from att_transaction
  where att_date >= '' and att_date <= ''
 -- with cteCheckIN as (
 --select row_number() OVER (ORDER BY att_datetime asc) ID, pers_person_pin, att_datetime, DATEDIFF(MI,att_datetime, LEAD(att_datetime) OVER (order by ID asc)) as diffDateTime, DATEPART(DD, att_datetime) as Day, DATEPART(MM,att_datetime) as Month, DATEPART(HH, att_datetime) as Hour, DATEPART(MI,att_datetime) as Minute
 --from att_transaction where att_date >= '2022-06-02' and  att_date <= '2022-06-02' and device_sn = '4879202300002' and pers_person_pin = '15517' 
 --)
 --select pers_person_pin, att_datetime,
 --CASE 
	--WHEN diffDateTime IS NULL AND LAG(diffDateTime) OVER (order by ID asc) NOT LIKE '0' THEN COALESCE(diffDateTime, 4)
	--ELSE DATEDIFF(MI,att_datetime, LEAD(att_datetime) OVER (order by ID asc))
	--END as timeDiff
 --into #MyTemp1
 --from cteCheckIN;
 --select row_number() OVER (ORDER BY att_datetime asc) No, pers_person_pin, att_datetime
 --into #MyOut1
 --from #MyTemp1 where timeDiff > 2;

 --  with cteCheckOUT as (
 --select row_number() OVER (ORDER BY att_datetime asc) ID, pers_person_pin, att_datetime, DATEDIFF(MI,att_datetime, LEAD(att_datetime) OVER (order by ID asc)) as diffDateTime, DATEPART(DD, att_datetime) as Day, DATEPART(MM,att_datetime) as Month, DATEPART(HH, att_datetime) as Hour, DATEPART(MI,att_datetime) as Minute
 --from att_transaction where att_date >= '2022-06-02' and  att_date <= '2022-06-02' and device_sn = '4879202300009' and pers_person_pin = '15517' 
 --)
 --select pers_person_pin, att_datetime,
 --CASE 
	--WHEN diffDateTime IS NULL AND LAG(diffDateTime) OVER (order by ID asc) NOT LIKE '0' THEN COALESCE(diffDateTime, 4)
	--ELSE DATEDIFF(MI,att_datetime, LEAD(att_datetime) OVER (order by ID asc))
	--END as timeDiff
 --into #MyTemp2
 --from cteCheckOUT;
 --select row_number() OVER (ORDER BY att_datetime asc) No, pers_person_pin, att_datetime
 --into #MyOut2
 --from #MyTemp2 where timeDiff > 2;


 --select *
 --from #MyOut1 as a, 
 --#MyOut2 b where a.pers_person_pin = b.pers_person_pin and a.No = b.No

 --DROP TABLE #MyTemp1
 --drop table #MyOut1
 --DROP TABLE #MyTemp2
 --Drop table #MyOut2