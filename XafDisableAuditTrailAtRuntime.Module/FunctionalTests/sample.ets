;#DropDB XafDisableAuditTrailAtRuntimeEasyTest

#Application XafDisableAuditTrailAtRuntimeWin
#Application XafDisableAuditTrailAtRuntimeWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef XafDisableAuditTrailAtRuntimeWin

*Action About...
 
*Action OK

#EndIf

#IfDef XafDisableAuditTrailAtRuntimeWeb
*Action Navigation(My Details)
#EndIf
