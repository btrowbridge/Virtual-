using SmartHome.Devices;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Helper variadic functions
//Warning, can be expensive
public static class DeviceHelper  {

    public static List<SmartDevice> GetGroupFromDeviceLists(string groupName, params List<SmartDevice>[] lists) 
    {
        return lists.SelectMany(list => list)
            .Where(dev => dev.DevInfo.GroupName == groupName)
            .OrderByDescending(x => x).ToList();
    }
    public static List<SmartDevice> GetAllDevices( params List<SmartDevice>[] lists)
    {
        return lists.SelectMany(list => list).ToList();
    }
    public static void AddDevicesFromListsToGroup(List<string> deviceNames, string groupName, params List<SmartDevice>[] lists)
    {
        lists.SelectMany(list => list)
            .Where(dev => deviceNames.Contains(dev.DevInfo.Name))
            .ToList().ForEach(dev => dev.DevInfo.GroupName = groupName);

    }
    public static List<string> GetGroupNames(params List<SmartDevice>[] lists)
    {
        return lists.SelectMany(list => list)
            .Select(list => list.DevInfo.GroupName).Distinct()
            .OrderByDescending(x=>x).ToList();
    }
    public static List<string> GetDeviceNames(params List<SmartDevice>[] lists)
    {
        return lists.SelectMany(list => list)
            .Select(list => list.DevInfo.Name).Distinct()
            .OrderByDescending(x => x).ToList();
    }
    public static List<string> GetDeviceNamesFromGroup(string groupName, params List<SmartDevice>[] lists)
    {
        return lists.SelectMany(list => list)
            .Where(dev => dev.DevInfo.GroupName == groupName)
            .Select(dev => dev.DevInfo.Name).ToList();
    }
    public static List<string> GetDeviceNamesFromGroups(List<string> groupNames, params List<SmartDevice>[] lists)
    {
        return lists.SelectMany(list => list)
            .Where(dev => groupNames.Contains(dev.DevInfo.GroupName))
            .Select(dev => dev.DevInfo.Name).ToList();
    }
}
