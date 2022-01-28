using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bosca_Dana_Music.Data;
using Bosca_Dana_Music.Models;

namespace Bosca_Dana_Music.Controllers
{
    public class SongsController : Controller
    {
        private readonly Bosca_Dana_MusicContext _context;

        public SongsController(Bosca_Dana_MusicContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {

            var songs = await _context.Song
                .Include(s => s.Artist)
                .Include(s => s.Genre)
                .ToListAsync();

            foreach (Song song in songs)
            {
                var artist = await _context.Artist.FirstOrDefaultAsync(a => a.ArtistId == song.ArtistId);
                var genre = await _context.Genre.FirstOrDefaultAsync(g => g.GenreId == song.GenreId);
                song.Genre = genre;
                song.Artist = artist;
            }

            return View(songs);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Artist)
                .Include(s => s.Genre)
                .FirstOrDefaultAsync(m => m.SongId == id);

            var artist = await _context.Artist.FirstOrDefaultAsync(a => a.ArtistId == song.ArtistId);
            var genre = await _context.Genre.FirstOrDefaultAsync(g => g.GenreId == song.GenreId);

            song.Genre = genre;
            song.Artist = artist;
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }
        private void PopulateGenresList(object selectedGenre = null)
        {
            var genreQuery = from g in _context.Genre
                             orderby g.Name
                             select g;
            ViewBag.GenreId = new SelectList(genreQuery.AsNoTracking(), "GenreId", "Name", selectedGenre);
        }
        private void PopulateArtistsList(object selectedArtist = null)
        {
            var artistQuery = from a in _context.Artist
                              orderby a.Name
                              select a;
            ViewBag.ArtistId = new SelectList(artistQuery.AsNoTracking(), "ArtistId", "Name", selectedArtist);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            PopulateGenresList();
            PopulateArtistsList();
            //ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId");
            //ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ReleasedYear,ArtistId,GenreId")] Song song)
        {
            if (ModelState.IsValid)
            {
                Song last = _context.Song.OrderByDescending(s => s.SongId).FirstOrDefault();

                _context.Entry(song.Genre).State = EntityState.Unchanged;
                _context.Entry(song.Artist).State = EntityState.Unchanged;

                song.SongId = last.SongId + 1;

                song.Genre = null;
                song.Artist = null;

                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateGenresList(song.GenreId);
            PopulateArtistsList(song.ArtistId);
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            PopulateGenresList();
            PopulateArtistsList();
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,Name,ReleasedYear,ArtistId,GenreId")] Song song)
        {
            if (id != song.SongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(song.Genre).State = EntityState.Unchanged;
                    _context.Entry(song.Artist).State = EntityState.Unchanged;

                    song.Genre = null;
                    song.Artist = null;

                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.SongId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateGenresList(song.GenreId);
            PopulateArtistsList(song.ArtistId);
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Artist)
                .Include(s => s.Genre)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Song.FindAsync(id);
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.SongId == id);
        }
    }
}
