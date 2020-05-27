﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Demo.Models.Api;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.Repositories
{
    public class DatabaseStudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseStudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Student> DeleteStudent(long id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var students = await _context.Student
                //.Include(student => student.Enrollments) // Causes cycle in serialization
                .Select(student => new StudentDTO
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,

                    Courses = student.Enrollments
                        .Select(e => new CourseDTO
                        {
                            Id = e.Course.Id,
                            CourseCode = e.Course.CourseCode,
                            TechnologyName = e.Course.Technology.Name,
                        })
                        .ToList(),
                })
                .ToListAsync();

            return students;
        }

        public async Task<StudentDTO> GetOneStudent(long id)
        {
            var student = await _context.Student
                // Rabbit hole of including all the things...still need Technology!
                //.Include(student => student.Enrollments)
                //    .ThenInclude(e => e.Course)

                // Project in SQL instead of C#!
                .Select(student => new StudentDTO
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,

                    Courses = student.Enrollments
                        .Select(e => new CourseDTO
                        {
                            Id = e.Course.Id,
                            CourseCode = e.Course.CourseCode,
                            TechnologyName = e.Course.Technology.Name,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(student => student.Id == id);

            return student;

            // Instead of projecting in C# on the web server
            //return new StudentDTO
            //{
            //    Id = student.Id,
            //    FirstName = student.FirstName,
            //    LastName = student.LastName,

            //    Courses = student.Enrollments
            //            .Select(e => new CourseDTO
            //            {
            //                Id = e.Course.Id,
            //                CourseCode = e.Course.CourseCode,
            //                TechnologyName = e.Course.Technology.Name,
            //            })
            //            .ToList(),
            //};
        }

        public async Task<Student> SaveNewStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateStudent(long id, Student student)
        {
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool StudentExists(long id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
