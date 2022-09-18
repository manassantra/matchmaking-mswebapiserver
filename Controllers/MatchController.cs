using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mswebapiserver.DTOs;
using mswebapiserver.Models.User;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;

namespace mswebapiserver.Controllers
{
    [Authorize]
    public class MatchController : BaseapiController
    {
        private readonly DatabaseContext _context;
        public MatchController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpPost("preferance/{id}")]
        public async Task<ActionResult<PartnerPreferanceDTO>> CreateMatchPreferance(int id, PartnerPreferanceDTO partnerPreferance)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);

            var details = new PartnerPreferance
            {
                userRefId = user.id,
                area = partnerPreferance.area,
                ageFrom = partnerPreferance.ageFrom,
                ageTo = partnerPreferance.ageTo,
                highetFrom = partnerPreferance.highetFrom,
                highetTo = partnerPreferance.highetTo,
                maritalStatus = partnerPreferance.maritalStatus,
                religion = partnerPreferance.religion,
                community = partnerPreferance.community,
                subCommunity = partnerPreferance.subCommunity,
                gothra = partnerPreferance.gothra,
                canSpeak = partnerPreferance.canSpeak,
                motherToung = partnerPreferance.motherToung,
                jobType = partnerPreferance.jobType,
                isPremium = user.isPremium,
                modifiedBy = user.email,
                modifiedOn = DateTime.Now
            };

            _context.PartnerPreferances.Add(details);
            await _context.SaveChangesAsync();

            return Ok("Partner Preferances Updated !");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PublicProfileDTO>> BestMatchsProfiles(int id)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);
            var userList = new List<PublicProfileDTO>();
            var userPref = _context.PartnerPreferances.FirstOrDefault(x => x.userRefId == id);
            IList<PartnerPreferance> allPreferences = _context.PartnerPreferances.Where(x => x.userRefId != id
                                                        && (x.area == userPref.area || x.area == "NA")
                                                        && (x.religion == userPref.religion || x.religion == "NA")
                                                        && (x.community == userPref.community || x.community == "NA")
                                                        && (x.motherToung == userPref.motherToung || x.motherToung == "NA")
                                                        && (x.jobType == userPref.jobType || x.jobType == "NA")).ToList();
            foreach (var u in allPreferences)
            {
                var userDetails = _context.AppUsers.FirstOrDefault(x => x.id == u.userRefId);
                var imageDetails = _context.ProfilePictures.FirstOrDefault(x => x.userRefid == userDetails.id);
                if (((userPref.ageFrom >= u.ageFrom) && (userPref.ageFrom <= u.ageTo)) || ((userPref.ageTo >= u.ageFrom) && (userPref.ageTo <= u.ageTo)))
                {
                    if (((toInches(userPref.highetFrom) >= toInches(u.highetFrom)) && (toInches(userPref.highetFrom) <= toInches(u.highetTo))) || ((toInches(userPref.highetTo) >= toInches(u.highetFrom)) && (toInches(userPref.highetTo) <= toInches(u.highetTo))))
                    {
                        var following = _context.UserFollowers.FirstOrDefault(x => x.followedUserId == u.userRefId);
                        if (following == null)
                        {
                            var details = new PublicProfileDTO
                            {
                                userRefId = u.userRefId,
                                userName = userDetails.fullName,
                                image = imageDetails.imageFilename,
                                isFollowed = false,
                            };
                            userList.Add(details);
                        }


                        else
                        {
                            var details = new PublicProfileDTO
                            {
                                userRefId = u.userRefId,
                                userName = userDetails.fullName,
                                image = imageDetails.imageFilename,
                                isFollowed = (bool)following.isFollowing
                            };
                            userList.Add(details);
                        }
                    }

                }
            }

            return Ok(userList);
        }


        private int toInches(string input)
        {
            if (input.Contains("."))
            {
                string sfeet = input.Split('.')[0];
                string sinches = input.Split('.')[1];
                int feet, inches;
                if (int.TryParse(sfeet, out feet) && int.TryParse(sinches, out inches))
                {
                    return feet * 12 + inches;
                }
                throw new Exception("The input is invalid");
            }
            else
            {
                int output;
                if (int.TryParse(input, out output))
                {
                    return output * 12;
                }
                throw new Exception("The input is invalid");
            }
        }
    }
}
