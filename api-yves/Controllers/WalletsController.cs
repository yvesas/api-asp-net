using Repository;
using Core.Domain.Entities;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace api_yves.Controllers;


[ApiController]
[Route("api/[controller]")]
public class WalletsController : ControllerBase
{
  private readonly AppDbContext _context;

  public WalletsController(AppDbContext context)
  {
    _context = context;
  }

  // GET: api/wallets
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Wallet>>> GetWallets()
  {
    var wallets = await _context.Wallets.AsNoTracking().ToListAsync();
    return Ok(wallets);
  }

  // GET: api/wallets/5
  [HttpGet("{wallet}")]
  public async Task<ActionResult<Wallet>> GetWallet(int id)
  {
    var wallet = await _context.Wallets.FindAsync(id);

    if (wallet == null)
    {
      return NotFound();
    }

    return wallet;
  }

  // POST: api/wallets
  [HttpPost]
  public async Task<ActionResult<CreateWalletDTO>> PostWallet(CreateWalletDTO modelWallet)
  { 
    if(!ModelState.IsValid){
      return BadRequest();
    };

    var wallet = new Wallet {
      UserID = modelWallet.UserID,
      Amout = modelWallet.Amout,
      Bank = modelWallet.Bank
    };

    _context.Wallets.Add(wallet);
    await _context.SaveChangesAsync();

    var newWallet = CreatedAtAction(nameof(GetWallet), new { id = wallet.Id }, wallet);

    return Ok(newWallet);
  }

  // PUT: api/wallets/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutWallet(int id, Wallet wallet)
  {
    if (id != wallet.Id)
    {
      return BadRequest();
    }

    _context.Entry(wallet).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!WalletExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return NoContent();
  }

  // DELETE: api/wallets/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteWallet(int id)
  {
    var wallet = await _context.Wallets.FindAsync(id);
    if (wallet == null)
    {
      return NotFound();
    }

    _context.Wallets.Remove(wallet);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool WalletExists(int id)
  {
    return _context.Wallets.Any(e => e.Id == id);
  }

}