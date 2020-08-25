#!/bin/bash
netcore_PID=`pgrep -l dotnet |awk '{print $1}'`
filePath=`pwd`
netcore_handles_logPath=""$filePath"/netcore_handlesOfProcess_log.txt"
netcore_mem_logPath=""$filePath"/netcore_mem_log.txt"
while : 
do
  netcore_handles_cmd=`lsof -n |  awk '{print $2}'| sort | uniq -c |grep -E "$netcore_PID" | awk `{print $1}``
  netcore_mem_cmd=`cat /proc/$netcore_PID/status|grep VmRSS | awk '{print $2}'`
  echo "$netcore_handles_cmd" >> $netcore_handles_logPath 
  echo "$netcore_mem_cmd" >> $netcore_mem_logPath 
  sleep 60
done
