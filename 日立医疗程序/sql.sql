select b.RepairMissionId,b.RepairMissionCode,b.RepairTypeNew,a.*                                                from FaultFeedback a inner join RepairMission b on a.RepairMissionID = b.RepairMissionID where a.FaultFeedbackID = 'bdb1685a-833b-42b7-8e43-24a0b58cc20a'


--获取操作员对应的上级部门
select distinct d.UserId,d.userName,d.Memo  
                                        from Users c
                                        inner join Users d on (case when c.ismanager=1 and len(c.deptNum)>2 then substring(c.deptNum,1,len(c.deptNum)-2) else c.deptNum end)  = d.deptNum
                                        where c.UserId='{0}' and d.ismanager=1 and d.[State] = 1 and d.UserId != 'linwei'