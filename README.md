# FluffyRunner

FluffyRunner je 2D endless runner igra razvijena u **Unity 6** okruženju korišćenjem programskog jezika **C#**. Igrač upravlja psom koji prolazi kroz tri različita tematska okruženja, sakuplja kosti i izbegava prepreke. Kako igra napreduje, uvode se nove prepreke i povećava se brzina kretanja, čime igra postaje sve izazovnija.

---

# Početni ekran

Početni ekran igre modelovan je u **Blender-u**, a zatim integrisan u Unity kao uvodna scena sa dugmetom **START** za pokretanje igre.

> <img width="843" height="380" alt="image" src="https://github.com/user-attachments/assets/3820765c-fe20-4016-8acf-e25374cbcb37" />
> <img width="842" height="382" alt="image" src="https://github.com/user-attachments/assets/fe1423fa-3006-490d-af9e-a2176119c86e" />


---

# Gameplay

Cilj igre je sakupljanje kostiju uz uspešno izbegavanje prepreka. Nakon ispunjavanja cilja trenutnog nivoa, igrač prelazi u novo okruženje sa drugačijim preprekama i povećanom težinom igre.

## Grad

**Cilj:**
- Sakupiti **10 kostiju**

**Prepreke:**
- Kanta za smeće

> <img width="841" height="381" alt="image" src="https://github.com/user-attachments/assets/ae0e4d82-678d-4897-b5ec-97eb4aabc0a9" />
> <img width="839" height="384" alt="image" src="https://github.com/user-attachments/assets/12fa2a84-227a-4133-a679-e338efc83469" />



---

## Šuma

**Cilj:**
- Sakupiti **20 kostiju**

**Prepreke:**
- Pečurka
- Ptica

> <img width="838" height="382" alt="WhatsApp Image 2026-07-09 at 21 45 37" src="https://github.com/user-attachments/assets/f94a82e0-9802-4348-be26-a87479314372" />


---

## Plaža

Plaža predstavlja poslednji nivo igre.

**Prepreke:**
- Suncobran

Na ovom nivou brzina psa je dodatno povećana, čime igra postaje zahtevnija.

> <img width="838" height="382" alt="WhatsApp Image 2026-07-09 at 21 45 37" src="https://github.com/user-attachments/assets/b24fe2cf-ec5f-41b5-92b7-5f9b846615ec" />


---

# Funkcionalnosti

- 2D endless runner igra
- Tri različita tematska nivoa
- Nasumično generisanje prepreka
- Sistem sakupljanja kostiju
- Automatski prelazak između nivoa
- Povećanje brzine psa nakon prelaska na novi nivo
- Promena pozadine u zavisnosti od nivoa
- Detekcija sudara sa preprekama
- Uvodna scena kreirana u Blender-u

---

# Kontrole

| Taster | Akcija |
|--------|--------|
| **Space** | Skok |
| **START** | Pokretanje igre |

---

# Tehnologije

- Unity 6
- C#
- Blender
- Git
- GitHub

---

# Struktura projekta

```
Assets
├── Audio
├── Background
├── Prefabs
│   └── Obstacles
│       ├── City
│       ├── Forest
│       └── Beach
├── Scenes
├── Scripts
├── SpritesCity
├── SpritesForest
├── SpritesBeach
└── UI
```

---

# Pokretanje projekta

1. Klonirati repozitorijum:

```bash
git clone https://github.com/vanjazivanovic/FluffyRunner.git
```

2. Otvoriti projekat u **Unity Hub-u**.
3. Otvoriti glavnu scenu projekta.
4. Pokrenuti igru klikom na dugme **Play** u Unity Editor-u.

---


# Repozitorijum

https://github.com/vanjazivanovic/FluffyRunner
