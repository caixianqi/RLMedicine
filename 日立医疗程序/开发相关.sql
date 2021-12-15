--//Lin修改 2019-02-20 
select * from TFunctions

--RepairtypeNew nvarchar(10) null
--维修任务
select  RepairMissionCode,RepairtypeNew,* from RepairMission where RepairMissionCode='RE00016084'

select  RepairMissionCode,RepairtypeNew,* from RepairMission where RepairMissionCode='RE00016082'


select code,code+'-'+name as name from BaseGuaranteeType order by code

select AuditerCode, AuditName, ApplicationPersonCode,AuditerCode, RepairtypeNew,AuditTime,AuditName,ApplicationPersonCode,* from PartsApplication where PartsApplicationCode='PA00013976'

select AuditerCode, AuditName, ApplicationPersonCode,AuditerCode, RepairtypeNew,AuditTime,AuditName,ApplicationPersonCode,* from PartsApplication
where AuditerCode <>''

update PartsApplication set ApplicationPersonCode='demo',AuditerCode='demo' where PartsApplicationCode='PA00013976'

exec sp_PartsInentoryNewList '2019-02-03','2019-03-03','','','demo'
                               , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), "", this.cmbStatus.SelectedItem.ToString(), UFBaseLib.BusLib.BaseInfo.DBUserID);


select * from  PartsApplicationDetails

select AuditName,AuditTime ,RepairtypeNew,* from PartsApplication

where AuditName is not null order by AuditTime desc

select * from PartsInventory
select * from BaseGuaranteeType

--C类维修
--RE00016031

--F类维修
--RE00004986(审核)
--RE00004896(已结案)
--RE00004849(审核)

select RepairMissionCode,AuditPerson,* from FreeApplication 

--RepairPersonCode ='{0}' 
--RepairtypeNew = 'C' 314
--RepairtypeNew = 'F'	5	                                                   
select * from RepairMission 
                                                    where  RepairMissionCode not in (select RepairMissionCode from Price) 
		                                                    and (RepairtypeNew = 'C' or  RepairtypeNew = 'F') 
		                                                    and RepairMissionCode not in (select RepairMissionCode from FreeApplication where isnull(AuditPerson,'') <>'') 
		                                                    and isEnd is null
		                                                    
		                                                    
select * from [Price]

select name as code,code+'-'+name as name,comment from BaseFinalSolution order by code


select * from TMessageAuto where BillCode='RE00016117'
