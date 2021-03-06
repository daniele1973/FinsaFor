﻿using FinsaWeb.DTO;
using FinsaWeb.DTO.Extentions;
using FinsaWeb.Models;
using FinsaWeb.Models.CoreNocciolo.UoW;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Allievi")]
    [EnableCors("MyPolicyCORS")]
    public class APIAllieviController : Controller
    {
        public const string ROUTE_GET_ALLIEVI = "ROUTE_GET_ALLIEVI";
        private IAllieviUnitOfWork work;
        public APIAllieviController(IAllieviUnitOfWork work)
        {
            this.work = work;
        }

        [HttpGet("{id}", Name = ROUTE_GET_ALLIEVI)]
        public IActionResult Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            Allievo stud = work.AllieviRepo.Find(id);
            if (stud == null)
            {
                return NotFound();
            }
            return Ok(stud.ToDTO());
        }

        [HttpGet("{id}/corsi")]
        public IActionResult GetCourse(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            List<CorsoDTO> corsi = work.AllieviRepo.EnrollmentsForStudent(id).Select(x=>x.ToDTO()).ToList();
            if (corsi == null)
            {
                return NotFound();
            }
            return Ok(corsi);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var studente = work.AllieviRepo.FindAll().Select(d => d.ToDTO());
            return Ok(studente);
        }


        [HttpPost]
        public IActionResult Crea([FromBody] AllievoDTO studDTO)
        {
            if (studDTO == null)
            {
                return BadRequest();
            }
            Allievo stud = studDTO.ToAllievo();
            work.Begin();
            work.AllieviRepo.Add(stud);
            work.Save();
            work.End();
            return CreatedAtRoute(ROUTE_GET_ALLIEVI, new { id = stud.IdStudente }, stud.ToDTO()); //risp al client
        }

        [HttpPut]
        public IActionResult Update([FromBody] AllievoDTO studDTO)
        {
            if (studDTO == null)
            {
                return BadRequest();
            }
            Allievo doc = studDTO.ToAllievo();
            try
            {
                work.Begin();
                work.AllieviRepo.Update(doc);
                work.Save();
                work.End();

            }
            catch (DataException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            if (id < 1 )
            {
                return BadRequest();
            }
            try
            {
                work.Begin();
                work.AllieviRepo.Delete(id);
                work.Save();
                work.End();

            }
            catch (DataException)
            {
                return NotFound();
            }
            //var studente = work.AllieviRepo.FindAll().Select(d => d.ToDTO());
            //return Ok(studente);
            return Ok();
        }
    }
}
