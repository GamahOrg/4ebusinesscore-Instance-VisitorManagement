

using _4EPlatform.Domain.Models.CheckIn_OutVisitor;
using _4EPlatform.Domain.Models.Parking;

namespace _4EPlatForm.Infrastructure.Context;
public class ContextSeedData
{
    private static DBContext _dbContext;
    private static IServiceProvider _serviceProvider;
    private static IConfiguration _config;


    public static void Seed(DBContext appDbContext, IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _dbContext = appDbContext;
        _dbContext.Database.EnsureCreated();
        _serviceProvider = serviceProvider;
        _config = configuration;


        SeedPermissionType();
        SeedPermissionsSource();
        if (bool.TryParse(_config["IsSeedData"], out bool isSeedData) && isSeedData)
        {
            SeedGroup();
            SeedPermission();
            SeedVisitor();
            SeedParking();
            SeedCheckIn_OutVisitor();
            SeedViolation();
            SeedCancelRequest();
            SeedVisitorPermissionSteps(); 
        }
        // call functions

    }

    private static void SeedPermissionType()
    {
        string PermissionTypeJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "PermissionTypeSeedData.json");
        var PermissionTypes = JsonConvert.DeserializeObject<List<LK_PermissionType>>(PermissionTypeJson);

        if (PermissionTypes != null && PermissionTypes.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.LK_PermissionType.Any())
                {
                    foreach (var PermissionType in PermissionTypes)
                    {
                        PermissionType.CreatedOn = DateTime.Now;
                    }

                    _dbContext.LK_PermissionType.AddRange(PermissionTypes);
                    _dbContext.SaveChanges();
                }
                else
                {
                    var existingPermissionType = _dbContext.LK_PermissionType.ToList();
                    var newPermissionTypes = PermissionTypes
                        .Where(na => existingPermissionType.Any(ea => ea.NameEn == na.NameEn))
                        .ToList();

                    if (!newPermissionTypes.Any())
                    {
                        foreach (var PermissionType in newPermissionTypes)
                        {
                            PermissionType.CreatedOn = DateTime.Now;
                        }

                        _dbContext.LK_PermissionType.AddRange(newPermissionTypes);
                        _dbContext.SaveChanges();
                    }
                }
            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
    private static void SeedPermissionsSource()
    {
        string permissionsSourceJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "PermissionsSourceSeedData.json");
        var permissionsSource = JsonConvert.DeserializeObject<List<LK_PermissionSource>>(permissionsSourceJson);

        if (permissionsSource != null && permissionsSource.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.LK_PermissionSource.Any())
                {
                    foreach (var permissionSource in permissionsSource)
                    {
                        permissionSource.CreatedOn = DateTime.Now;
                    }

                    _dbContext.LK_PermissionSource.AddRange(permissionsSource);
                    _dbContext.SaveChanges();
                }
                else
                {
                    var existingPermissionsSource = _dbContext.LK_PermissionSource.ToList();
                    var newPermissionsSource = permissionsSource
                        .Where(nk => !existingPermissionsSource.Any(ek => ek.NameEN == nk.NameEN))
                        .ToList();

                    if (newPermissionsSource.Any())
                    {
                        foreach (var permissionSource in newPermissionsSource)
                        {
                            permissionSource.CreatedOn = DateTime.Now;
                        }

                        _dbContext.LK_PermissionSource.AddRange(newPermissionsSource);
                        _dbContext.SaveChanges();
                    }

                }
            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
    private static void SeedGroup()
    {
        string GroupJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "GroupsSeedData.json");
        var GroupsJson = JsonConvert.DeserializeObject<List<Group>>(GroupJson);

        if (GroupsJson != null && GroupsJson.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.Groups.Any())
                {
                    foreach (var Group in GroupsJson)
                    {
                        Group.CreatedOn = DateTime.Now;
                    }

                    _dbContext.Groups.AddRange(GroupsJson);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
    private static void SeedPermission()
    {
        string PermissionJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "PermissionSeedData.json");
        var PermissionsJson = JsonConvert.DeserializeObject<List<Permission>>(PermissionJson);

        if (PermissionsJson != null && PermissionsJson.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.Permissions.Any())
                {
                    foreach (var Permission in PermissionsJson)
                    {
                        Permission.CreatedOn = DateTime.Now;
                    }

                    _dbContext.Permissions.AddRange(PermissionsJson);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
    private static void SeedVisitor()
    {
        string VisitorJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "VisitorSeedData.json");
        var VisitorsJson = JsonConvert.DeserializeObject<List<Visitor>>(VisitorJson);

        if (VisitorsJson != null && VisitorsJson.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.Visitors.Any())
                {
                    foreach (var Visitor in VisitorsJson)
                    {
                        Visitor.CreatedOn = DateTime.Now;
                    }

                    _dbContext.Visitors.AddRange(VisitorsJson);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
    private static void SeedParking()
    {
        string ParkingJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "ParkingSeedData.json");
        var ParkingsJson = JsonConvert.DeserializeObject<List<Parking>>(ParkingJson);

        if (ParkingsJson != null && ParkingsJson.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.Parking.Any())
                {
                    foreach (var Visitor in ParkingsJson)
                    {
                        Visitor.CreatedOn = DateTime.Now;
                    }

                    _dbContext.Parking.AddRange(ParkingsJson);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
    private static void SeedCheckIn_OutVisitor()
    {
        string CheckIn_OutVisitorJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "CheckIn_OutVisitorSeedData.json");
        var CheckIn_OutVisitorsJson = JsonConvert.DeserializeObject<List<CheckIn_OutVisitor>>(CheckIn_OutVisitorJson);

        if (CheckIn_OutVisitorsJson != null && CheckIn_OutVisitorsJson.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.CheckIn_OutVisitor.Any())
                {
                    foreach (var Visitor in CheckIn_OutVisitorsJson)
                    {
                        Visitor.CreatedOn = DateTime.Now;
                    }

                    _dbContext.CheckIn_OutVisitor.AddRange(CheckIn_OutVisitorsJson);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
    private static void SeedViolation()
    {
        string ViolationJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "ViolationSeedData.json");
        var ViolationsJson = JsonConvert.DeserializeObject<List<Violation>>(ViolationJson);

        if (ViolationsJson != null && ViolationsJson.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.Violation.Any())
                {
                    foreach (var Violation in ViolationsJson)
                    {
                        Violation.CreatedOn = DateTime.Now;
                    }

                    _dbContext.Violation.AddRange(ViolationsJson);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
    private static void SeedCancelRequest()
    {
        string CancelRequestJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "CancelRequestSeedData.json");
        var CancelRequestsJson = JsonConvert.DeserializeObject<List<CancelRequest>>(CancelRequestJson);

        if (CancelRequestsJson != null && CancelRequestsJson.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.CancelRequest.Any())
                {
                    foreach (var Request in CancelRequestsJson)
                    {
                        Request.CreatedOn = DateTime.Now;
                    }

                    _dbContext.CancelRequest.AddRange(CancelRequestsJson);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }
    private static void SeedVisitorPermissionSteps()
    {
        string VisitorPermissionStepJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "VisitorPermissionSteps.json");
        var VisitorPermissionStepsJson = JsonConvert.DeserializeObject<List<VisitorPermissionSteps>>(VisitorPermissionStepJson);

        if (VisitorPermissionStepsJson != null && VisitorPermissionStepsJson.Any())
        {
            _dbContext.Database.OpenConnection();
            try
            {
                if (!_dbContext.VisitorPermissionSteps.Any())
                {
                    foreach (var Step in VisitorPermissionStepsJson)
                    {
                        Step.CreatedOn = DateTime.Now;
                    }

                    _dbContext.VisitorPermissionSteps.AddRange(VisitorPermissionStepsJson);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }

}







