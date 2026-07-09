# FluffyRunner

FluffyRunner je 2D endless runner igra razvijena u **Unity 6** okruženju korišćenjem programskog jezika **C#**. Igrač upravlja psom koji prolazi kroz tri različita tematska okruženja, sakuplja kosti i izbegava prepreke. Kako igra napreduje, uvode se nove prepreke i povećava se brzina kretanja, čime igra postaje sve izazovnija. Tokom igre reprodukuju se zvučni efekti koji dodatno doprinose atmosferi i iskustvu igranja.

---

# Početni ekran

Početni ekran igre modelovan je u **Blender-u**, a zatim integrisan u Unity kao uvodna scena sa dugmetom **START** za pokretanje igre.


---

# Gameplay

Cilj igre je sakupljanje kostiju uz uspešno izbegavanje prepreka. Nakon ispunjavanja cilja trenutnog nivoa, igrač prelazi u novo okruženje sa drugačijim preprekama i povećanom težinom igre.

## Grad

**Cilj:**
- Sakupiti **10 kostiju**

**Prepreke:**
- Kanta za smeće



---

## Šuma

**Cilj:**
- Sakupiti **20 kostiju**

**Prepreke:**
- Pečurka
- Ptica


---

## Plaža

Plaža predstavlja poslednji nivo igre.

**Prepreke:**
- Suncobran

Na ovom nivou brzina psa je dodatno povećana, čime igra postaje zahtevnija.

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
- Zvučni efekti koji prate gameplay i interakcije u igri
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
