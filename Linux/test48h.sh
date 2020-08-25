#!/bin/bash
java_PID=`jps |grep Bootstrap | awk '{print $1}'`
machine_PID=`jps |grep machineagent | awk '{print $1}'`
filePath=`pwd`
java_handles_logPath=""$filePath"/java_handlesOfProcess_log.txt"
machine_handles_logPath=""$filePath"/machine_handlesOfProcess_log.txt"
java_mem_logPath=""$filePath"/java_mem_log.txt"
machine_mem_logPath=""$filePath"/machine_mem_log.txt"
while : 
do
  java_handles_cmd=`lsof -n |  awk '{print $2}'| sort | uniq -c |grep -E "$java_PID" | awk '{print $1}' `
  machine_handles_cmd=`lsof -n |  awk '{print $2}'| sort | uniq -c |grep -E "$machine_PID" | awk '{print $1}'`
  
  java_mem_cmd=`cat /proc/$java_PID/status|grep VmRSS | awk '{print $2}'`
  machine_mem_cmd=`cat /proc/$machine_PID/status|grep VmRSS | awk '{print $2}'`
  echo "$java_handles_cmd" >> $java_handles_logPath
  echo "$machine_handles_cmd" >> $machine_handles_logPath
  echo "$java_mem_cmd" >> $java_mem_logPath
  echo "$machine_mem_cmd" >> $machine_mem_logPath
  sleep 60
done
