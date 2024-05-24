//using system;
//using system.collections.generic;
//using system.linq;
//using system.threading.tasks;
//using microsoft.aspnetcore.mvc;
//using microsoft.aspnetcore.mvc.rendering;
//using microsoft.entityframeworkcore;
//using optimization.models;

//namespace optimization.controller
//{
//    public class customermodelscontroller : controller
//    {
//        private readonly optimizationcontext _context;

//        public customermodelscontroller(optimizationcontext context)
//        {
//            _context = context;
//        }

//        // get: customermodels
//        public async task<ıactionresult> ındex()
//        {
//            return _context.customermodel != null ?
//                        view(await _context.customermodel.tolistasync()) :
//                        problem("entity set 'optimizationcontext.customermodel'  is null.");
//        }

//        // get: customermodels/details/5
//        public async task<ıactionresult> details(int? id)
//        {
//            if (id == null || _context.customermodel == null)
//            {
//                return notfound();
//            }

//            var customermodel = await _context.customermodel
//                .firstordefaultasync(m => m.ıd == id);
//            if (customermodel == null)
//            {
//                return notfound();
//            }

//            return view(customermodel);
//        }

//        // get: customermodels/create
//        public ıactionresult create()
//        {
//            return view();
//        }

//        // post: customermodels/create
//        // to protect from overposting attacks, enable the specific properties you want to bind to.
//        // for more details, see http://go.microsoft.com/fwlink/?linkıd=317598.
//        [httppost]
//        [validateantiforgerytoken]
//        public async task<ıactionresult> create([bind("ıd,name,surname,address,phonenumber")] customermodel customermodel)
//        {
//            if (modelstate.ısvalid)
//            {
//                _context.add(customermodel);
//                await _context.savechangesasync();
//                return redirecttoaction(nameof(ındex));
//            }
//            return view(customermodel);
//        }

//        // get: customermodels/edit/5
//        public async task<ıactionresult> edit(int? id)
//        {
//            if (id == null || _context.customermodel == null)
//            {
//                return notfound();
//            }

//            var customermodel = await _context.customermodel.findasync(id);
//            if (customermodel == null)
//            {
//                return notfound();
//            }
//            return view(customermodel);
//        }

//        // post: customermodels/edit/5
//        // to protect from overposting attacks, enable the specific properties you want to bind to.
//        // for more details, see http://go.microsoft.com/fwlink/?linkıd=317598.
//        [httppost]
//        [validateantiforgerytoken]
//        public async task<ıactionresult> edit(int? id, [bind("ıd,name,surname,address,phonenumber")] customermodel customermodel)
//        {
//            if (id != customermodel.ıd)
//            {
//                return notfound();
//            }

//            if (modelstate.ısvalid)
//            {
//                try
//                {
//                    _context.update(customermodel);
//                    await _context.savechangesasync();
//                }
//                catch (dbupdateconcurrencyexception)
//                {
//                    if (!customermodelexists(customermodel.ıd))
//                    {
//                        return notfound();
//                    }
//                    else
//                    {
//                        throw;
//                    //}
//                }
//                return redirecttoaction(nameof(ındex));
//            }
//            return view(customermodel);
//        }

//        // get: customermodels/delete/5
//        public async task<ıactionresult> delete(int? id)
//        {
//            if (id == null || _context.customermodel == null)
//            {
//                return notfound();
//            }

//            var customermodel = await _context.customermodel
//                .firstordefaultasync(m => m.ıd == id);
//            if (customermodel == null)
//            {
//                return notfound();
//            }

//            return view(customermodel);
//        }

//        // post: customermodels/delete/5
//        [httppost, actionname("delete")]
//        [validateantiforgerytoken]
//        public async task<ıactionresult> deleteconfirmed(int? id)
//        {
//            if (_context.customermodel == null)
//            {
//                return problem("entity set 'optimizationcontext.customermodel'  is null.");
//            }
//            var customermodel = await _context.customermodel.findasync(id);
//            if (customermodel != null)
//            {
//                _context.customermodel.remove(customermodel);
//            }

//            await _context.savechangesasync();
//            return redirecttoaction(nameof(ındex));
//        }

//        private bool customermodelexists(int? id)
//        {
//            return (_context.customermodel?.any(e => e.ıd == id)).getvalueordefault();
//        }
//    }
//}
